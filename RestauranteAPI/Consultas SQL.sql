--use Restaurante;



--1
select C.Categoria, count(*) as NumeroPlatos 
from Categoria as C 
inner join Platos as P
On C.IdCategoria = P.IdPlato
Group By C.Categoria;

--2
--Ingredientes por plato
select P.Plato, count(*) as NumeroIngredientes 
from PlatoIngrediente as P_I
inner join Platos as P
On P_I.Plato = P.IdPlato
Group By P.Plato;

--3
select Top 3 Plato, Descripcion 
From Platos
order by IdPlato DESC;

--4
--Platos con ingrediente
select P.Plato from Platos P
inner join PlatoIngrediente P_I
On P.IdPlato = P_I.Plato

--6
--Descripcion Ingredientes
Select Ingrediente, Descripcion
from Ingredientes

--7

select P.Plato, count(*) as NumeroEtiquetas
from PlatoEtiqueta as PE
inner join Platos as P
On P.IdPlato = PE.IdPlato
Group By P.Plato;


Create Procedure