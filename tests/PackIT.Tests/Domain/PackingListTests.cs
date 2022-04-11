using PackIT.Domain.Entities;
using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.Factories;
using PackIT.Domain.Policies;
using PackIT.Domain.ValueObjects;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PackIT.Tests.Domain
{
    public class PackingListTests
    {
        [Fact]
        public void AddItem_ThrowsPackingItemAlreadyExistException_WhenThereIsAnItemWithTheSameName()
        {
            // Arrange
            var packingList = GetPackingList();
            packingList.AddItem(new PackingItem("Item 1", 1));

            // Act
            var exception =  Record.Exception(() => packingList.AddItem(new PackingItem("Item 1", 1)));

            // Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PackingListItemAlreadyExistException>();

        }

        [Fact]
        public void AddItem_ReturnPackingItemAddedEvent_OnSuccess()
        {
            var packingList = GetPackingList();

            var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item 1", 1)));

            exception.ShouldBeNull();
            packingList.Events.Count().ShouldBe(1);

            var @event = packingList.Events.FirstOrDefault() as PackingItemAdded;

            @event.ShouldNotBeNull();
            @event.PackingItem.Name.ShouldBe("Item 1");

        }

        #region Arrange

        private PackingList GetPackingList()
        {
            var packingList = _factory.Create(Guid.NewGuid(), "MyList", Localization.Create("Tunis, Tunisia"));
            packingList.ClearEvents();
            return packingList;
        }

        private readonly IPackingListFactory _factory;

        public PackingListTests()
        {
            _factory = new PackingListFactory(Enumerable.Empty<IPackingItemPolicy>());
        } 
        #endregion
    }
}
