namespace GestionLogisticaTestUnitario
{
    using GestionLogisticaApiR.AccesoDatos;
    using GestionLogisticaApiR.DTO;
    using GestionLogisticaApiR.LogicaNegocio.Validadores;
    using GestionLogisticaApiR.Models;
    using Moq;

    [TestClass]
    public class TestUnitario
    {
        [TestMethod]
        //Ejecuta prueba para verificar si existe la bodega con el tipo de logistica terrestre
        [DataRow("36984", "1", "Bod01-Bog")]
        //Ejecuta prueba para verificar si existe el puerto con el tipo de logistica marítima
        [DataRow("36984", "2", "Pue01-Mi")]
        public void ExistenciaTodosLosRegistros(string? documento, string? idTipoProducto, string? nombreLocacion)
        {
            //Arrange
            Mock<IGenericoAD<Cliente>> clienteAD = new Mock<IGenericoAD<Cliente>>();
            Mock<IGenericoAD<TipoProducto>> tipoProductoAD = new Mock<IGenericoAD<TipoProducto>>();
            Mock<IConsultaEntidadAD<Bodega>> bodegaAD = new Mock<IConsultaEntidadAD<Bodega>>();
            Mock<IConsultaEntidadAD<Puerto>> puertoAD = new Mock<IConsultaEntidadAD<Puerto>>();

            clienteAD.Setup(a => a.ConsultarEntidad(documento)).Returns(new Cliente() { Documento = "36984", Nombres = "Pepito", Apellidos = "Pérez", Direccion = "Calle 1", CorreoElectronico = "Pepito@correo.com"});
            tipoProductoAD.Setup(b => b.ConsultarEntidad(idTipoProducto)).Returns(new TipoProducto() { Id= 1, Nombre = "Contenedores" , IdLogistica = 1 });
            bodegaAD.Setup(c => c.ConsultarEntidad(nombreLocacion)).Returns(new Bodega() { Id = 1, Nombre = "Bod01-Bog", Direccion = "calle 25", IdCiudad = 1 });
            puertoAD.Setup(d => d.ConsultarEntidad(nombreLocacion)).Returns(new Puerto() { Id = 1, Nombre = "Pue01-Mi", IdCiudad = 29 });
            ValidadorPlanEntrega validador = new ValidadorPlanEntrega(clienteAD.Object, tipoProductoAD.Object, bodegaAD.Object, puertoAD.Object);
            
            //Act
            ResultadoValidacion resultado = validador.ValidarExistenciaEntidades(documento, idTipoProducto, nombreLocacion);

            //Assert
            Assert.AreEqual("Registros existen", resultado.Mensaje);

        }

        [TestMethod]
        //El cliente no está creado
        [DataRow("3698224", "1", "Bod01-Bog")]
        public void NoExisteCliente(string? documento, string? idTipoProducto, string? nombreLocacion)
        {
            //Arrange
            Mock<IGenericoAD<Cliente>> clienteAD = new Mock<IGenericoAD<Cliente>>();
            Mock<IGenericoAD<TipoProducto>> tipoProductoAD = new Mock<IGenericoAD<TipoProducto>>();
            Mock<IConsultaEntidadAD<Bodega>> bodegaAD = new Mock<IConsultaEntidadAD<Bodega>>();
            Mock<IConsultaEntidadAD<Puerto>> puertoAD = new Mock<IConsultaEntidadAD<Puerto>>();

            clienteAD.Setup(a => a.ConsultarEntidad(documento)).Returns(new Cliente() { Documento = "36984", Nombres = "Pepito", Apellidos = "Pérez", Direccion = "Calle 1", CorreoElectronico = "Pepito@correo.com" });
            tipoProductoAD.Setup(b => b.ConsultarEntidad(idTipoProducto)).Returns(new TipoProducto() { Id = 1, Nombre = "Contenedores", IdLogistica = 1 });
            bodegaAD.Setup(c => c.ConsultarEntidad(nombreLocacion)).Returns(new Bodega() { Id = 1, Nombre = "Bod01-Bog", Direccion = "calle 25", IdCiudad = 1 });
            puertoAD.Setup(d => d.ConsultarEntidad(nombreLocacion)).Returns(new Puerto() { Id = 1, Nombre = "Pue01-Mi", IdCiudad = 29 });
            ValidadorPlanEntrega validador = new ValidadorPlanEntrega(clienteAD.Object, tipoProductoAD.Object, bodegaAD.Object, puertoAD.Object);

            //Act
            ResultadoValidacion resultado = validador.ValidarExistenciaEntidades(documento, idTipoProducto, nombreLocacion);

            //Assert
            Assert.AreEqual("El registro cliente no está creado", resultado.Mensaje);

        }

        [TestMethod]
        //Tipo producto no está creado
        [DataRow("36984", "3", "Bod01-Bog")]
        public void NoExisteTipoProducto(string? documento, string? idTipoProducto, string? nombreLocacion)
        {
            //Arrange
            Mock<IGenericoAD<Cliente>> clienteAD = new Mock<IGenericoAD<Cliente>>();
            Mock<IGenericoAD<TipoProducto>> tipoProductoAD = new Mock<IGenericoAD<TipoProducto>>();
            Mock<IConsultaEntidadAD<Bodega>> bodegaAD = new Mock<IConsultaEntidadAD<Bodega>>();
            Mock<IConsultaEntidadAD<Puerto>> puertoAD = new Mock<IConsultaEntidadAD<Puerto>>();

            clienteAD.Setup(a => a.ConsultarEntidad(documento)).Returns(new Cliente() { Documento = "36984", Nombres = "Pepito", Apellidos = "Pérez", Direccion = "Calle 1", CorreoElectronico = "Pepito@correo.com" });
            tipoProductoAD.Setup(b => b.ConsultarEntidad(idTipoProducto)).Returns(new TipoProducto() { Id = 1, Nombre = "Contenedores", IdLogistica = 1 });
            bodegaAD.Setup(c => c.ConsultarEntidad(nombreLocacion)).Returns(new Bodega() { Id = 1, Nombre = "Bod01-Bog", Direccion = "calle 25", IdCiudad = 1 });
            puertoAD.Setup(d => d.ConsultarEntidad(nombreLocacion)).Returns(new Puerto() { Id = 1, Nombre = "Pue01-Mi", IdCiudad = 29 });
            ValidadorPlanEntrega validador = new ValidadorPlanEntrega(clienteAD.Object, tipoProductoAD.Object, bodegaAD.Object, puertoAD.Object);

            //Act
            ResultadoValidacion resultado = validador.ValidarExistenciaEntidades(documento, idTipoProducto, nombreLocacion);

            //Assert
            Assert.AreEqual("El registro Tipo producto no está creado", resultado.Mensaje);

        }

        [TestMethod]
        // El nombre de la bodega o el puerto no corresponde a la logística (Terrestre o marítima)
        [DataRow("36984", "1", "Pue01-Mi")]
        public void AlmacenamientoErrado(string? documento, string? idTipoProducto, string? nombreLocacion)
        {
            //Arrange
            Mock<IGenericoAD<Cliente>> clienteAD = new Mock<IGenericoAD<Cliente>>();
            Mock<IGenericoAD<TipoProducto>> tipoProductoAD = new Mock<IGenericoAD<TipoProducto>>();
            Mock<IConsultaEntidadAD<Bodega>> bodegaAD = new Mock<IConsultaEntidadAD<Bodega>>();
            Mock<IConsultaEntidadAD<Puerto>> puertoAD = new Mock<IConsultaEntidadAD<Puerto>>();

            clienteAD.Setup(a => a.ConsultarEntidad(documento)).Returns(new Cliente() { Documento = "36984", Nombres = "Pepito", Apellidos = "Pérez", Direccion = "Calle 1", CorreoElectronico = "Pepito@correo.com" });
            tipoProductoAD.Setup(b => b.ConsultarEntidad(idTipoProducto)).Returns(new TipoProducto() { Id = 1, Nombre = "Contenedores", IdLogistica = 1 });
            bodegaAD.Setup(c => c.ConsultarEntidad(nombreLocacion)).Returns(new Bodega() { Id = 1, Nombre = "Bod01-Bog", Direccion = "calle 25", IdCiudad = 1 });
            puertoAD.Setup(d => d.ConsultarEntidad(nombreLocacion)).Returns(new Puerto() { Id = 1, Nombre = "Pue01-Mi", IdCiudad = 29 });
            ValidadorPlanEntrega validador = new ValidadorPlanEntrega(clienteAD.Object, tipoProductoAD.Object, bodegaAD.Object, puertoAD.Object);

            //Act
            ResultadoValidacion resultado = validador.ValidarExistenciaEntidades(documento, idTipoProducto, nombreLocacion);

            //Assert
            Assert.AreEqual("El registro de la Bodega no está creado", resultado.Mensaje);

        }

        [TestMethod]
        [DataRow("jlo442")]
        public void ValidarFormatoPlaca(string? numeroPlaca)
        {
            //Arrange
            Mock<IGenericoAD<Cliente>> clienteAD = new Mock<IGenericoAD<Cliente>>();
            Mock<IGenericoAD<TipoProducto>> tipoProductoAD = new Mock<IGenericoAD<TipoProducto>>();
            Mock<IConsultaEntidadAD<Bodega>> bodegaAD = new Mock<IConsultaEntidadAD<Bodega>>();
            Mock<IConsultaEntidadAD<Puerto>> puertoAD = new Mock<IConsultaEntidadAD<Puerto>>();

            ValidadorPlanEntrega validador = new ValidadorPlanEntrega(clienteAD.Object, tipoProductoAD.Object, bodegaAD.Object, puertoAD.Object);

            //Act
            bool exito = validador.ValidarNumeroPlaca(numeroPlaca);

            //Assert
            Assert.IsTrue(exito);

        }

        [TestMethod]
        [DataRow("gfg4524k")]
        public void ValidarFormatoNumeroFlota(string? numeroFlota)
        {
            //Arrange
            Mock<IGenericoAD<Cliente>> clienteAD = new Mock<IGenericoAD<Cliente>>();
            Mock<IGenericoAD<TipoProducto>> tipoProductoAD = new Mock<IGenericoAD<TipoProducto>>();
            Mock<IConsultaEntidadAD<Bodega>> bodegaAD = new Mock<IConsultaEntidadAD<Bodega>>();
            Mock<IConsultaEntidadAD<Puerto>> puertoAD = new Mock<IConsultaEntidadAD<Puerto>>();

            ValidadorPlanEntrega validador = new ValidadorPlanEntrega(clienteAD.Object, tipoProductoAD.Object, bodegaAD.Object, puertoAD.Object);

            //Act
            bool exito = validador.ValidarNumeroFlota(numeroFlota);

            //Assert
            Assert.IsTrue(exito);
        }

        [TestMethod]
        [DataRow("4j1hj1h2jj")]
        public void ValidarFormatoNumeroGuia(string? numeroGuia)
        {
            //Arrange
            Mock<IGenericoAD<Cliente>> clienteAD = new Mock<IGenericoAD<Cliente>>();
            Mock<IGenericoAD<TipoProducto>> tipoProductoAD = new Mock<IGenericoAD<TipoProducto>>();
            Mock<IConsultaEntidadAD<Bodega>> bodegaAD = new Mock<IConsultaEntidadAD<Bodega>>();
            Mock<IConsultaEntidadAD<Puerto>> puertoAD = new Mock<IConsultaEntidadAD<Puerto>>();

            ValidadorPlanEntrega validador = new ValidadorPlanEntrega(clienteAD.Object, tipoProductoAD.Object, bodegaAD.Object, puertoAD.Object);

            //Act
            bool exito = validador.ValidarNumeroGuia(numeroGuia);

            //Assert
            Assert.IsTrue(exito);
        }
    }
}