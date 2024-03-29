﻿using CKK.Logic.Models;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace StructuredProject1.Logic.TestsForStudents
{
    public class StoreTests
    {
        [Fact]
        public void GetSetId_ShouldSetAndReturnCorrectId()
        {
            try
            {
                //Assemble
                Store store = new();
                int expected = 54321;
                //Act
                store.Id = expected;
                int actual = store.Id;
                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The Correct Id Was not given.");
            }
        }

        [Fact]
        public void GetSetName_ShouldSetAndReturnCorrectName()
        {
            try
            {
                //Assemble
                Store store = new();
                var expected = "David Everton";

                //Act
                store.Name = expected;
                var actual = store.Name;

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The Correct Name was not given.");
            }
        }

        [Fact]
        public void AddStoreItem_With_Existing()
        {
            var prod1 = new Product();
            var prod2 = new Product();
            prod1.Id = 11111111;
            prod2.Id = 22222222;
            List<StoreItem> inventory = new List<StoreItem> { new StoreItem(prod1, 5), new StoreItem(prod2, 2) };
            var testStore = new Store(inventory);

            var expected = new StoreItem(prod1, 8);
            var actual = testStore.AddStoreItem(prod1, 3);

            Assert.True(expected.Product.Id == actual.Product.Id && expected.Quantity == actual.Quantity);
        } 

        

        [Fact]
        public void AddStoreItem_NewItem()
        {
            var prod1 = new Product();
            var prod2 = new Product();
            prod1.Id = 11111111;
            prod2.Id = 22222222;
            List<StoreItem> inventory = new List<StoreItem> { new StoreItem(prod1, 5) };
            var testStore = new Store(inventory);
            var expected = new StoreItem(prod2, 80);
            var actual = testStore.AddStoreItem(prod2, 80);

            Assert.True(expected.Product.Id == actual.Product.Id && expected.Quantity == actual.Quantity);
        }

        [Fact]
        public void RemoveStoreItem_ShouldRemoveSelectedItem()
        {
            try
            {
                //Assemble
                Store store = new();
                var product1 = new Product();
                product1.Id = 11111111;
                var product2 = new Product();
                product2.Id = 22222222;
                var product3 = new Product();
                product3.Id = 33333333;
                store.AddStoreItem(product1, 2);
                store.AddStoreItem(product2, 54);
                store.AddStoreItem(product3, 3);

                //Act
                store.RemoveStoreItem(11111111, 2);

                //Assert
                Assert.True(store.GetStoreItems()[0].Quantity == 0);
            }
            catch
            {
                throw new XunitException("The item was not removed correctly");
            }
        }

        [Fact]
        public void FindStoreItemById_ShouldReturnCorrectItem()
        {
            try
            {
                //Asemble
                Store store = new();
                var product1 = new Product();
                product1.Id = 1;
                var product2 = new Product();
                product2.Id = 2;
                var expected = new Product();
                expected.Id = 3;

                store.AddStoreItem(product1);
                store.AddStoreItem(product2);
                store.AddStoreItem(expected);
                //Act
                var actual = store.FindStoreItemById(3);

                //Assert
                Assert.Equal(expected.Id, actual.Product.Id);
            }catch
            {
                throw new XunitException("Did not return the correct item.");
            }
        }

        [Fact]
        public void FindStoreItemById_ShouldReturnNullNotFound()
        {
            try
            {
                //Asemble
                Store store = new();
                var product1 = new Product();
                product1.Id = 1;
                var product2 = new Product();
                product2.Id = 2;
                var expected = new Product();
                expected.Id = 3;

                store.AddStoreItem(product1);
                store.AddStoreItem(product2);
                store.AddStoreItem(expected);

                //Act
                var shouldBeNull = store.FindStoreItemById(15);

                //Assert
                Assert.Null(shouldBeNull);

            }
            catch
            {
                throw new XunitException("Method did not return null");
            }
        }

        [Fact]
        public void FindStoreItemById_ShouldReturnFirstIfMultiple()
        {
            try
            {
                //Asemble
                Store store = new();
                var expected = new Product();
                expected.Id = 1;
                var product2 = new Product();
                product2.Id = 1;
                var product3 = new Product();
                product3.Id = 1;

                store.AddStoreItem(expected);
                store.AddStoreItem(product2);
                store.AddStoreItem(product3);

                //Act
                var actual = store.FindStoreItemById(1);

                //Assert
                Assert.Equal(expected.Id, actual.Product.Id);
            }
            catch
            {
                throw new XunitException("Did not return correct Item.");
            }
        }
    }
}
