using System;
using JuegoOlimpico.Testing.Application.App_Start;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using JuegoOlimpico.Application.DTO;
using JuegoOlimpico.Application.Main;
using JuegoOlimpico.Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using JuegoOlimpico.Transversal.Common;

namespace JuegoOlimpico.Testing.Application
{
    [TestClass]
    public class NLogTest: BaseMockTest
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext ctx)
        {
            Register();
        }

        #region Sync

        #region Add
        [TestMethod]
        public void AddNLog_DatosCompletos_OK()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.Add(It.IsAny<Domain.Entities.Custom.NLog>()));

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = nLogApplication.Add(Mock.Of<NLogForCreationRequestDto>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }

        [TestMethod]
        public void AddNLog_DatosCompletos_Exception()
        {
            // Arrange
            const bool responseIsSuccess = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.Add(It.IsAny<Domain.Entities.Custom.NLog>()))
                .Throws(new Exception());

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = nLogApplication.Add(Mock.Of<NLogForCreationRequestDto>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
        }

        [TestMethod]
        public void AddNLog_DatosNulos_ManejoErrores()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = true;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.Add(It.IsAny<Domain.Entities.Custom.NLog>()));

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = nLogApplication.Add(null);

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }
        #endregion

        #region Delete
        [TestMethod]
        public void DeleteNLog_DatosCompletos_OK()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.Delete(It.IsAny<int>()));

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = nLogApplication.Delete(It.IsAny<int>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }

        [TestMethod]
        public void DeleteNLog_DatosCompletos_Exception()
        {
            // Arrange
            const bool responseIsSuccess = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.Delete(It.IsAny<int>()))
                .Throws(new Exception());

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = nLogApplication.Delete(It.IsAny<int>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
        }
        #endregion

        #region GetAll
        [TestMethod]
        public void GetAllNLog_DatosCompletos_OK()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = false;

            //Mocks
            AsignarMockContext();
            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.GetAll())
                .Returns(Enumerable.Repeat(It.IsAny<Domain.Entities.Custom.NLog>(), Constantes.LengthListTest));

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = nLogApplication.GetAll();

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }

        [TestMethod]
        public void GetAllNLog_DatosCompletos_Exception()
        {
            // Arrange
            const bool responseIsSuccess = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.GetAll())
                .Throws(new Exception());

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = nLogApplication.GetAll();

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
        }
        #endregion

        #region GetAllPaging
        [TestMethod]
        public void GetAllPagingNLog_DatosCompletos_OK()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = false;

            //Mocks
            AsignarMockContext();
            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.GetAllPaging(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(Enumerable.Repeat(It.IsAny<Domain.Entities.Custom.NLog>(), Constantes.LengthListTest));

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = nLogApplication.GetAllPaging(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }

        [TestMethod]
        public void GetAllPagingNLog_DatosCompletos_Exception()
        {
            // Arrange
            const bool responseIsSuccess = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.GetAllPaging(It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new Exception());

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = nLogApplication.GetAllPaging(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
        }
        #endregion

        #region GetById
        [TestMethod]
        public void GetByIdNLog_DatosCompletos_OK()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(Mock.Of<Domain.Entities.Custom.NLog>());

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = nLogApplication.GetById(It.IsAny<int>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }

        [TestMethod]
        public void GetByIdNLog_DatosCompletos_Exception()
        {
            // Arrange
            const bool responseIsSuccess = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.GetById(It.IsAny<int>()))
                .Throws(new Exception());

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = nLogApplication.GetById(It.IsAny<int>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
        }
        #endregion

        #region Update
        [TestMethod]
        public void UpdateNLog_DatosCompletos_OK()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.Update(It.IsAny<Domain.Entities.Custom.NLog>()));

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = nLogApplication.Update(Mock.Of<NLogForUpdateRequestDto>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }

        [TestMethod]
        public void UpdateNLog_DatosCompletos_Exception()
        {
            // Arrange
            const bool responseIsSuccess = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.Update(It.IsAny<Domain.Entities.Custom.NLog>()))
                .Throws(new Exception());

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = nLogApplication.Update(Mock.Of<NLogForUpdateRequestDto>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
        }

        [TestMethod]
        public void UpdateNLog_DatosNulos_ManejoErrores()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = true;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.Update(It.IsAny<Domain.Entities.Custom.NLog>()));

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = nLogApplication.Update(null);

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }
        #endregion

        #endregion

        #region Async

        #region AddAsync
        [TestMethod]
        public async Task AddAsyncNLog_DatosCompletos_OK()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.Custom.NLog>()))
                .Returns(Task.FromResult(string.Empty));

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = await nLogApplication.AddAsync(Mock.Of<NLogForCreationRequestDto>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }

        [TestMethod]
        public async Task AddAsyncNLog_DatosCompletos_Exception()
        {
            // Arrange
            const bool responseIsSuccess = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.Custom.NLog>()))
                .Throws(new Exception());

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = await nLogApplication.AddAsync(Mock.Of<NLogForCreationRequestDto>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
        }

        [TestMethod]
        public async Task AddAsyncNLog_DatosNulos_ManejoErrores()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = true;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.Custom.NLog>()));

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = await nLogApplication.AddAsync(null);

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }
        #endregion

        #region DeleteAsync
        [TestMethod]
        public async Task DeleteAsyncNLog_DatosCompletos_OK()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.DeleteAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(string.Empty));

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = await nLogApplication.DeleteAsync(It.IsAny<int>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }

        [TestMethod]
        public async Task DeleteAsyncNLog_DatosCompletos_Exception()
        {
            // Arrange
            const bool responseIsSuccess = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.DeleteAsync(It.IsAny<int>()))
                .Throws(new Exception());

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = await nLogApplication.DeleteAsync(It.IsAny<int>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
        }
        #endregion

        #region GetAllAsync
        [TestMethod]
        public async Task GetAllAsyncNLog_DatosCompletos_OK()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = false;

            //Mocks
            AsignarMockContext();
            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(Enumerable.Repeat(It.IsAny<Domain.Entities.Custom.NLog>(), Constantes.LengthListTest)));

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = await nLogApplication.GetAllAsync();

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }

        [TestMethod]
        public async Task GetAllAsyncNLog_DatosCompletos_Exception()
        {
            // Arrange
            const bool responseIsSuccess = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.GetAllAsync())
                .Throws(new Exception());

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = await nLogApplication.GetAllAsync();

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
        }
        #endregion

        #region GetAllPagingAsync
        [TestMethod]
        public async Task GetAllPagingAsyncNLog_DatosCompletos_OK()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = false;

            //Mocks
            AsignarMockContext();
            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.GetAllPagingAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(Task.FromResult(Enumerable.Repeat(It.IsAny<Domain.Entities.Custom.NLog>(), Constantes.LengthListTest)));

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = await nLogApplication.GetAllPagingAsync(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }

        [TestMethod]
        public async Task GetAllPagingAsyncNLog_DatosCompletos_Exception()
        {
            // Arrange
            const bool responseIsSuccess = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.GetAllPagingAsync(It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new Exception());

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = await nLogApplication.GetAllPagingAsync(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
        }
        #endregion

        #region GetById
        [TestMethod]
        public async Task GetByIdAsyncNLog_DatosCompletos_OK()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(Mock.Of<Domain.Entities.Custom.NLog>()));

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = await nLogApplication.GetByIdAsync(It.IsAny<int>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }

        [TestMethod]
        public async Task GetByIdAsyncNLog_DatosCompletos_Exception()
        {
            // Arrange
            const bool responseIsSuccess = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Throws(new Exception());

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = await nLogApplication.GetByIdAsync(It.IsAny<int>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
        }
        #endregion

        #region UpdateAsync
        [TestMethod]
        public async Task UpdateAsyncNLog_DatosCompletos_OK()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.UpdateAsync(It.IsAny<Domain.Entities.Custom.NLog>()))
                .Returns(Task.FromResult(string.Empty));

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = await nLogApplication.UpdateAsync(Mock.Of<NLogForUpdateRequestDto>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }

        [TestMethod]
        public async Task UpdateAsyncNLog_DatosCompletos_Exception()
        {
            // Arrange
            const bool responseIsSuccess = false;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.UpdateAsync(It.IsAny<Domain.Entities.Custom.NLog>()))
                .Throws(new Exception());

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = await nLogApplication.UpdateAsync(Mock.Of<NLogForUpdateRequestDto>());

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
        }

        [TestMethod]
        public async Task UpdateAsyncNLog_DatosNulos_ManejoErrores()
        {
            // Arrange
            const bool responseIsSuccess = true;
            const bool responseIsWarning = true;

            //Mocks
            AsignarMockContext();

            Mock<INLogDomain> mockNLogDominio = new Mock<INLogDomain>();
            mockNLogDominio.Setup(x => x.UpdateAsync(It.IsAny<Domain.Entities.Custom.NLog>()));

            // Act
            NLogApplication nLogApplication = new NLogApplication(mockNLogDominio.Object);
            var respuesta = await nLogApplication.UpdateAsync(null);

            // Assert
            Assert.IsTrue(responseIsSuccess == respuesta.IsSuccess);
            Assert.IsTrue(responseIsWarning == respuesta.IsWarning);
        }
        #endregion

        #endregion
    }
}
