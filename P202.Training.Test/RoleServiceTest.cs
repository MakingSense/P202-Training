using AutoMapper;
using Moq;
using P202.Training.Data.Entities;
using P202.Training.Data.Repositories;
using P202.Training.Domain;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace P202.Training.Test
{
    public class RoleServiceTest
    {
        [Fact]
        public void CreateRole_PersistsChange()
        {
            // Arrange
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var mapperMock = new Mock<IMapper>();

            var modelRole = new Domain.Models.Role
            {
                Id = 1,
                Name = "Admin"
            };

            var entityRole = new Data.Entities.Role
            {
                Id = 1,
                Name = "Admin"
            };

            roleRepositoryMock.Setup(r => r.CreateRole(It.IsAny<Role>()));
            roleRepositoryMock.Setup(r => r.GetRole(It.IsAny<int>())).Returns(entityRole);

            mapperMock.Setup(m => m.Map<Domain.Models.Role, Data.Entities.Role>(It.IsAny<Domain.Models.Role>()))
                            .Returns(entityRole);
            mapperMock.Setup(m => m.Map<Data.Entities.Role, Domain.Models.Role>(It.IsAny<Data.Entities.Role>()))
                .Returns(modelRole);

            // Act
            var roleRepositoryMockObject = roleRepositoryMock.Object;
            var mappingServiceMockObject = mapperMock.Object;

            var roleService = new RoleService(roleRepositoryMockObject, mappingServiceMockObject);
            roleService.CreateRole(modelRole);

            //Assert that the Add method was called once
            roleRepositoryMock.Verify(x => x.CreateRole(It.IsAny<Data.Entities.Role>()), Times.Once());

            var expectedRole = roleService.ReadRole(1);

            // Assert
            Assert.Equal(modelRole.Name, expectedRole.Name);
        }

        [Fact]
        public void DeleteRole_PersistsChange()
        {
            //Arrange
            
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var mapperMock = new Mock<IMapper>();
            var deleteRole = new Role();
            roleRepositoryMock.Setup(x => x.DeleteRole(deleteRole));

            //Act
            roleRepositoryMock.Object.DeleteRole(deleteRole);            
            var roleService = new RoleService(roleRepositoryMock.Object, mapperMock.Object);
            roleService.DeleteRole(deleteRole.Id);

            //Assert
            roleRepositoryMock.Verify(x => x.DeleteRole(deleteRole), Times.Once());
        }

        [Fact]
        public void UpdateRole_PersistsChange()
        {
            //Arrange            
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var mapperMock = new Mock<IMapper>();
            var updateRole = new Role { Name = "new-role-name" };
            roleRepositoryMock.Setup(x => x.UpdateRole(updateRole)).Returns(updateRole);

            //Act
            roleRepositoryMock.Object.UpdateRole(updateRole);
            var roleService = new RoleService(roleRepositoryMock.Object, mapperMock.Object);
            var mapRole = mapperMock.Object.Map<Domain.Models.Role>(updateRole);
            roleService.UpdateRole(mapRole);

            //Assert
            roleRepositoryMock.Verify(x => x.UpdateRole(updateRole), Times.Once());
        }

        [Fact]
        public void GetRole_VerifyData()
        {
            // Arrange
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var mapperMock = new Mock<IMapper>();
            var entitiesRole = new Data.Entities.Role { Id = 1 };
            var modelRole = new Domain.Models.Role { Id = 1 };

            roleRepositoryMock.Setup(r => r.GetRole(It.IsAny<int>())).Returns(entitiesRole);

            mapperMock.Setup(m => m.Map<Data.Entities.Role, Domain.Models.Role>(It.IsAny<Data.Entities.Role>()))
                            .Returns(modelRole);

            // Act
            var mappingServiceMockObject = mapperMock.Object;
            var roleRepositoryMockObject = roleRepositoryMock.Object;

            var roleService = new RoleService(roleRepositoryMockObject, mappingServiceMockObject);
            var expectedRole = roleService.ReadRole(1);

            // Assert
            roleRepositoryMock.Verify(x => x.GetRole(It.IsAny<int>()), Times.Once());
            Assert.Equal(modelRole.Id, expectedRole.Id);
        }

        [Fact]
        public void GetRoles_ListData()
        {
            // Arrange
            var roleRepositoryMock = new Mock<IRoleRepository>();
            var mapperMock = new Mock<IMapper>();

            var rolEntitiesList = new List<Data.Entities.Role> {
                new Data.Entities.Role {
                    Name = "admin"
                },
                new Data.Entities.Role {
                    Name = "salesman"
                }
            };

            var rolModelsList = new List<Domain.Models.Role> {
                new Domain.Models.Role {
                    Name = "admin"
                },
                new Domain.Models.Role {
                    Name = "salesman"
                }
            };

            roleRepositoryMock.Setup(r => r.GetAllRoles()).Returns(rolEntitiesList);
            mapperMock.Setup(m => m.Map<IList<Data.Entities.Role>, IList<Domain.Models.Role>>(It.IsAny<IList<Data.Entities.Role>>()))
                .Returns(rolModelsList);

            var mappingServiceMockObject = mapperMock.Object;
            var roleRepositoryMockObject = roleRepositoryMock.Object;

            // Act
            var roleService = new RoleService(roleRepositoryMockObject, mappingServiceMockObject);
            var expectedRoles = roleService.ListRoles();

            //Assert that the List method was called once
            roleRepositoryMock.Verify(x => x.GetAllRoles(), Times.Once());

            // Assert
            Assert.Equal(2, expectedRoles.Count);
        }
    }
}
