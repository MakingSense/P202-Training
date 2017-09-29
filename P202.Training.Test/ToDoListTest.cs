using AutoMapper;
using Moq;
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
    
    public class ToDoListTest
    {
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
            var toDoItemService = new ToDoListService(toDoListRepositoryMockObject, mappingServiceMockObject);
            var expectedToDoList = toDoItemService.ListToDoList();

            //Assert that the List method was called once
            toDoListRepositoryMock.Verify(x => x.FindAll(), Times.Once());

            // Assert
            Assert.Equal(2, expectedToDoList.Count);
        }
    }
}
