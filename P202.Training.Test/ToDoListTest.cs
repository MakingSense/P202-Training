using AutoMapper;
using Moq;
using P202.Training.Data.Entities;
using P202.Training.Data.Repositories;
using P202.Training.Domain;
using System.Collections.Generic;
using Xunit;

namespace P202.Training.Test
{

    public class ToDoListTest
    {
        [Fact]
        public void CreateToDoList_PersistsChange()
        {
            // Arrange
            var ToDoListRepositoryMock = new Mock<IToDoListRepository>();
            var mapperMock = new Mock<IMapper>();

            var modelToDoList = new Domain.Models.ToDoList
            {
                Id = 1,
                Name = "ToDoList A"
            };

            var entityToDoList = new Data.Entities.ToDoList
            {
                Id = 1,
                Name = "ToDoList B"
            };

            ToDoListRepositoryMock.Setup(r => r.Create(It.IsAny<ToDoList>()));
            ToDoListRepositoryMock.Setup(r => r.FindById(It.IsAny<int>())).Returns(entityToDoList);

            mapperMock.Setup(m => m.Map<Domain.Models.ToDoList, Data.Entities.ToDoList>(It.IsAny<Domain.Models.ToDoList>()))
                            .Returns(entityToDoList);
            mapperMock.Setup(m => m.Map<Data.Entities.ToDoList, Domain.Models.ToDoList>(It.IsAny<Data.Entities.ToDoList>()))
                .Returns(modelToDoList);

            // Act
            var ToDoListRepositoryMockObject = ToDoListRepositoryMock.Object;
            var mappingServiceMockObject = mapperMock.Object;

            var ToDoListService = new ToDoListService(ToDoListRepositoryMockObject, mappingServiceMockObject);
            ToDoListService.CreateToDoList(modelToDoList);

            //Assert that the Add method was called once
            ToDoListRepositoryMock.Verify(x => x.Create(It.IsAny<Data.Entities.ToDoList>()), Times.Once());

            var expectedToDoList = ToDoListService.ReadToDoList(1);

            // Assert
            Assert.Equal(modelToDoList.Name, expectedToDoList.Name);
        }


        [Fact]
        public void GetToDoList_ListData()
        {
            // Arrange
            var toDoListRepositoryMock = new Mock<IToDoListRepository>();
            var mapperMock = new Mock<IMapper>();

            var toDoListEntitiesList = new List<Data.Entities.ToDoList> {
                new Data.Entities.ToDoList {
                    Name = "ToDoList A"
                },
                new Data.Entities.ToDoList {
                    Name = "ToDoList B"
                }
            };

            var toDoListModelsList = new List<Domain.Models.ToDoList> {
                new Domain.Models.ToDoList {
                    Name = "ToDoList A"
                },
                new Domain.Models.ToDoList {
                    Name = "ToDoList B"
                }
            };

            toDoListRepositoryMock.Setup(r => r.FindAll()).Returns(toDoListEntitiesList);
            mapperMock.Setup(m => m.Map<IList<Data.Entities.ToDoList>, IList<Domain.Models.ToDoList>>(It.IsAny<IList<Data.Entities.ToDoList>>()))
                .Returns(toDoListModelsList);

            var mappingServiceMockObject = mapperMock.Object;
            var toDoListRepositoryMockObject = toDoListRepositoryMock.Object;

            // Act
            var ToDoListService = new ToDoListService(toDoListRepositoryMockObject, mappingServiceMockObject);
            var expectedToDoList = ToDoListService.ListToDoList();

            //Assert that the List method was called once
            toDoListRepositoryMock.Verify(x => x.FindAll(), Times.Once());

            // Assert
            Assert.Equal(2, expectedToDoList.Count);
        }
    }
}
