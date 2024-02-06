use accounting;
/* 6 задание (Продемонстрировать возможность чтения незафиксированных изменений при 
использовании уровня изоляции READ UNCOMMITTED и отсутствие такой 
возможности при уровне изоляции READ COMMITTED)*/

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
start transaction;
select * from type_podrazdelenia;
select count(*) from type_podrazdelenia;
rollback;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
start transaction;
select * from type_podrazdelenia;
select count(*) from type_podrazdelenia;
rollback;

/* 7 задание (Продемонстрировать возможность записи в уже прочитанные данные при 
использовании уровня изоляции READ COMMITTED и отсутствие такой 
возможности при уровне изоляции REPEATABLE READ.)*/

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
start transaction;
select * from type_podrazdelenia;
rollback;

SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
start transaction;
select * from type_podrazdelenia;
rollback;