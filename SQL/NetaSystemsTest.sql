create database TEstNetaSystems

use TestNetaSystems
go

create table Facturacion(
Id int IDENTITY(1,1) primary key,
FechaFacturacion datetime not null,
CantidadFacturada decimal not null,
NombrePersona varchar(30)
)
go

create procedure sp_ObtenerFacturasXPagina
@noPagina int,
@registrosXPagina int
as
begin
select * from Facturacion order by FechaFacturacion ASC
OFFSET @noPagina * @registrosXPagina ROW
FETCH NEXT @registrosXPagina ROWS ONLY
end
go

exec sp_ObtenerFacturasXPagina 1, 10