using AutoMapper;
using Moq;
using P202.Training.Data.Entities;
using P202.Training.Data.Repositories;
using P202.Training.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace P202.Training.Test
{

    public class ToDoItemTest
    {
        [Fact]
        public void CreateToDoList_PersistsChange()
        {
            // Arrange
            var ToDoItemRepositoryMock = new Mock<IToDoItemRepository>();
            var mapperMock = new Mock<IMapper>();

            var modelToDoItem = new Domain.Models.ToDoItem
            {
                Id = 1,
                Description = "ToDoItem A"
            };

            var entityToDoItem = new Data.Entities.ToDoItem
            {
                Id = 1,
                Description = "ToDoItem B"
            };

            ToDoItemRepositoryMock.Setup(r => r.Create(It.IsAny<ToDoItem>()));
            ToDoItemRepositoryMock.Setup(r => r.FindById(It.IsAny<int>())).Returns(entityToDoItem);

            mapperMock.Setup(m => m.Map<Domain.Models.ToDoItem, Data.Entities.ToDoItem>(It.IsAny<Domain.Models.ToDoItem>()))
                            .Returns(entityToDoItem);
            mapperMock.Setup(m => m.Map<Data.Entities.ToDoItem, Domain.Models.ToDoItem>(It.IsAny<Data.Entities.ToDoItem>()))
                .Returns(modelToDoItem);

            // Act
            var ToDoItemRepositoryMockObject = ToDoItemRepositoryMock.Object;
            var mappingServiceMockObject = mapperMock.Object;

            var ToDoItemService = new ToDoItemService(ToDoItemRepositoryMockObject, mappingServiceMockObject);
            ToDoItemService.CreateToDoItem(modelToDoItem);

            //Assert that the Add method was called once
            ToDoItemRepositoryMock.Verify(x => x.Create(It.IsAny<Data.Entities.ToDoItem>()), Times.Once());

            var expectedToDoItem = ToDoItemService.ReadToDoItem(1);

            // Assert
            Assert.Equal(modelToDoItem.Description, expectedToDoItem.Description);
        }


        [Fact]
        public void GetToDoItem_ListData()
        {
            // Arrange
            var toDoItemRepositoryMock = new Mock<IToDoItemRepository>();
            var mapperMock = new Mock<IMapper>();

            var toDoItemEntitiesList = new List<Data.Entities.ToDoItem> {
                new Data.Entities.ToDoItem {
                    Description = "ToDoItem 1",
                    Priority = 1
                },
                new Data.Entities.ToDoItem {
                    Description = "ToDoItem 2",
                    Priority = 2
                }
            };

            var toDoItemModelsList = new List<Domain.Models.ToDoItem> {
                new Domain.Models.ToDoItem {
                    Description = "ToDoItem 1",
                    Priority = 1
                },
                new Domain.Models.ToDoItem {
                    Description = "ToDoItem 2",
                    Priority = 2
                }
            };

            toDoItemRepositoryMock.Setup(r => r.FindAll()).Returns(toDoItemEntitiesList);
            mapperMock.Setup(m => m.Map<IList<Data.Entities.ToDoItem>, IList<Domain.Models.ToDoItem>>(It.IsAny<IList<Data.Entities.ToDoItem>>()))
                .Returns(toDoItemModelsList);

            var mappingServiceMockObject = mapperMock.Object;
            var toDoItemRepositoryMockObject = toDoItemRepositoryMock.Object;

            // Act
            var toDoItemService = new ToDoItemService(toDoItemRepositoryMockObject, mappingServiceMockObject);
            var expectedToDoItem = toDoItemService.ListToDoItem();

            //Assert that the List method was called once
            toDoItemRepositoryMock.Verify(x => x.FindAll(), Times.Once());

            // Assert
            Assert.Equal(2, expectedToDoItem.Count);
        }

    }
}
