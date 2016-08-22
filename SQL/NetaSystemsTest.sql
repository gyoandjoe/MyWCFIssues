create database TEstNetaSystems

use TestNetaSystems
go

create table Factura(
Id int IDENTITY(1,1) primary key,
FechaFacturacion datetime not null,
CantidadFacturada decimal not null,
NombrePersona varchar(30)
)
go

insert into Factura(FechaFacturacion,CantidadFacturada,NombrePersona) values (GETDATE(),'92238','Ramos')
go	

alter procedure sp_ObtenerFacturasXPagina
@noPagina int,
@registrosXPagina int
as
begin
set @noPagina = @noPagina-1
select * from Factura order by FechaFacturacion ASC
OFFSET @noPagina * @registrosXPagina ROW
FETCH NEXT @registrosXPagina ROWS ONLY
end
go


select * from Factura


exec sp_ObtenerFacturasXPagina 3, 2


