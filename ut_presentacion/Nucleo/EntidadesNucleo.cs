using Lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public static class EntidadesNucleo
    {
       
        public static Membresias? Membresias()
        {
            var entidad = new Membresias();
            entidad.Tipo = "Membresía-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Precio = 50000;
            entidad.Beneficio = "Descuento especial";
            entidad.Fecha_inicio = DateTime.Now;
            entidad.Fecha_fin = DateTime.Now.AddMonths(12);
            return entidad;
        }

        
        public static Clientes? Clientes()
        {
            var entidad = new Clientes();
            entidad.Nombre = "Cliente-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Email = "cliente@test.com";
            entidad.Direccion = "Calle 123";
            entidad.Telefono = "3019876543";
            entidad.Fecha_registro = DateTime.Now;
            entidad.Membresia = 1; // Use existing membresia
            return entidad;
        }

    
        public static Empleados? Empleados()
        {
            var entidad = new Empleados();
            entidad.Nombre = "Empleado-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Puesto = "Vendedor";
            entidad.Telefono = "3001234567";
            entidad.Email = "empleado@test.com";
            entidad.Fecha_contratacion = DateTime.Now;
            return entidad;
        }

      
        public static Proveedores? Proveedores()
        {
            var entidad = new Proveedores();
            entidad.Nombre = "Proveedor-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Telefono = "3021234567";
            entidad.Email = "proveedor@test.com";
            entidad.Direccion = "Carrera 45 #67";
            entidad.Ciudad = "Medellín";
            return entidad;
        }

        
        public static Categorias? Categorias()
        {
            var entidad = new Categorias();
            entidad.Nombre = "Categoria-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Descripcion = "Categoría de prueba";
            entidad.Estado = true;
            entidad.Prioridad = 1;
            entidad.Fecha_creacion = DateTime.Now;
            return entidad;
        }

        public static Inventarios? Inventarios()
        {
            var entidad = new Inventarios();
            entidad.Tipo_producto = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Stock = 80;
            entidad.Nombre = "Producto Inventario";
            entidad.Ubicacion = "Bodega 1";
            entidad.Fecha_actualizacion = DateTime.Now;
            return entidad;
        }

      
        public static Comics? Comics()
        {
            var entidad = new Comics();
            entidad.Nombre = "Comic-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Editorial = "Marvel";
            entidad.Autor = "Autor X";
            entidad.Ilustrador = "Ilustrador Y";
            entidad.Precio = 25000;
            entidad.Categoria = 1; // Use existing categoria
            entidad.Inventario = 1; // Use existing inventario
            return entidad;
        }

        public static Promociones? Promociones()
        {
            var entidad = new Promociones();
            entidad.Descripcion = "Promo-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Descuento = 10;
            entidad.Fecha_inicio = DateTime.Now;
            entidad.Fecha_fin = DateTime.Now.AddMonths(1);
            entidad.Codigo = "PROMO10";
            return entidad;
        }

       
        public static Comic_promociones? Comic_promociones()
        {
            var entidad = new Comic_promociones();
            entidad.Fecha_asignacion = DateTime.Now;
            entidad.Estado = "Activo";
            entidad.Aplicacion = "General";
            entidad.Tipo_promocion = "Descuento";
            entidad.Observaciones = "Aplicado al comic";
            entidad.Promocion = 1; // Use existing promocion
            entidad.Comic = 1; // Use existing comic
            return entidad;
        }

        
        public static Compras? Compras()
        {
            var entidad = new Compras();
            entidad.Fecha_compra = DateTime.Now;
            entidad.Nombre_comic = "Compra-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            entidad.Cantidad = 3;
            entidad.Total = 75000;
            entidad.Estado_compra = "Pagada";
            entidad.Cliente = 1; // Use existing cliente
            return entidad;
        }

        
        public static Pagos? Pagos()
        {
            var entidad = new Pagos();
            entidad.Metodo = "Tarjeta";
            entidad.Fecha_pago = DateTime.Now;
            entidad.Monto = 50000;
            entidad.Estado = "Aprobado";
            entidad.Referencia_transaccion = "TX-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            return entidad;
        }

       
        public static DetalleCompras? DetalleCompras()
        {
            var entidad = new DetalleCompras();
            entidad.Precio_unitario = 25000;
            entidad.Cantidad = 3;
            entidad.Subtotal = 75000;
            entidad.Descuento = 0;
            entidad.Tipo_producto_comprado = "Comic";
            entidad.Compra = 1; // Use existing compra
            entidad.Comic = 1; // Use existing comic
            entidad.Pago = 1; // Use existing pago
            return entidad;
        }

       
        public static Ventas? Ventas()
        {
            var entidad = new Ventas();
            entidad.Fecha_venta = DateTime.Now;
            entidad.Total = 150000;
            entidad.Metodo_pago = "Efectivo";
            entidad.Estado_venta = "Completada";
            entidad.Tipo_venta = "Mostrador";
            entidad.Empleado = 1; // Use existing empleado
            entidad.Proveedor = 1; // Use existing proveedor
            entidad.Membresia = 1; // Use existing membresia
            return entidad;
        }

      
        public static DetalleVentas? DetalleVentas()
        {
            var entidad = new DetalleVentas();
            entidad.Precio_unitario = 25000;
            entidad.Cantidad = 2;
            entidad.Subtotal = 50000;
            entidad.Descuento = 0;
            entidad.Tipo_producto_vendido = "Comic";
            entidad.Venta = 1; // Use existing venta
            entidad.Comic = 1; // Use existing comic
            return entidad;
        }

      
        public static Devoluciones? Devoluciones()
        {
            var entidad = new Devoluciones();
            entidad.Motivo = "Defectuoso";
            entidad.Fecha_inicio = DateTime.Now;
            entidad.Fecha_fin = DateTime.Now.AddDays(2);
            entidad.Estado_devolucion = "Pendiente";
            entidad.Cantidad_devuelta = 1;
            entidad.Cliente = 1; // Use existing cliente
            entidad.Detalle_compra = 1; // Use existing detalle_compra
            return entidad;
        }
    }
}
