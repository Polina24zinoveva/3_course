use accounting;

/* 1 задание (Создать два не обновляемых представления, возвращающих пользователю 
результат из нескольких таблиц, с разными алгоритмами обработки 
представления)*/

-- представление "Сумма стоимости всего оборудования по типам подразделений"
create algorithm = merge view sum_equipment_type_podrazdelenia 
as select type_podrazdelenia.name_type_podrazdelenia AS 'Тип подразделения',
SUM(equipment.price) AS 'Сумма стоимости всего оборудования по типам подразделений'
FROM podrazdelenie, type_podrazdelenia, equipment
WHERE podrazdelenie.type_podrazdelenia = type_podrazdelenia.id_type_podrazdelenia
AND equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia
GROUP BY type_podrazdelenia.id_type_podrazdelenia;

select * from sum_equipment_type_podrazdelenia;

-- drop view responsible_person_equpment;

-- представление "Сумма стоимости всего оборудования по типам подразделений"
create algorithm = temptable view sum_equipment_responsible_person 
as select SUM(equipment.price) AS 'Сумма стоимости всего оборудования по ответственным лицам', 
responsible_person.surname_person, responsible_person.name_person, 
responsible_person.middle_name_person
FROM equipment, responsible_person, podrazdelenie 
WHERE equipment.id_podrazdelenia = podrazdelenie.id_podrazdelenia
AND responsible_person.id_podrazdelenia = podrazdelenie.id_podrazdelenia
GROUP BY responsible_person.id_responsible_person;


select * from sum_equipment_responsible_person;

/* 2 задание (Создать обновляемое представление, не позволяющее выполнить команду 
INSERT)*/
create view equipment_v
as select name_equipment, price
FROM equipment;

select * from equipment_v;

-- пример, что insert не работает:
INSERT INTO equipment_v (name_equipment, price)
VALUES ('стол', 2000);

/* 3 задание (Создать обновляемое представление, позволяющее выполнить команду INSERT)*/
create view type_podrazdelenia_v
as select id_type_podrazdelenia, name_type_podrazdelenia
FROM type_podrazdelenia;

select * from type_podrazdelenia_v;

-- пример, что insert работает:
INSERT INTO type_podrazdelenia_v (id_type_podrazdelenia, name_type_podrazdelenia)
VALUES (5, 'цех');
-- delete from type_podrazdelenia where id_type_podrazdelenia = 5;

/* 4 задание (Создать вложенное обновляемое представление с проверкой ограничений (WITH 
CHECK OPTION).)*/
create view equipment_written_off_false
as select id_equipment, name_equipment, price, id_podrazdelenia, written_off
from equipment
where written_off = false
with check option;

-- пример, что insert не работает, так как в equipment_written_off_false written_off может быть только false:
INSERT INTO equipment_written_off_false (id_equipment, name_equipment, price, id_podrazdelenia, written_off)
VALUES (1020, 'стол', 2000, 101, true);

/* 5 задание (Создайте транзакцию, произведите ее откат и фиксацию:
a. Отключите режим автоматического завершения;
b. Добавьте в выбранную таблицу новые записи, проверьте добавились ли 
они;
c. Произведите откат транзакции, т. е. отмену произведенных действий;
d. Откатите транзакцию оператором ROLLBACK(изменения не 
сохранились);
e. Воспроизведите транзакцию и сохраните действия оператором 
COMMIT)*/
set AUTOCOMMIT=0;

start transaction;
INSERT INTO type_podrazdelenia(id_type_podrazdelenia, name_type_podrazdelenia)
VALUES (10, 'цех');
INSERT INTO type_podrazdelenia (id_type_podrazdelenia, name_type_podrazdelenia)
VALUES (11, 'отделение');
select * from type_podrazdelenia;
rollback;

start transaction;
INSERT INTO type_podrazdelenia(id_type_podrazdelenia, name_type_podrazdelenia)
VALUES (10, 'цех');
INSERT INTO type_podrazdelenia (id_type_podrazdelenia, name_type_podrazdelenia)
VALUES (11, 'отделение');
select * from type_podrazdelenia;
commit;

-- delete from type_podrazdelenia where id_type_podrazdelenia >= 10;


/* 6 задание (Продемонстрировать возможность чтения незафиксированных изменений при 
использовании уровня изоляции READ UNCOMMITTED и отсутствие такой 
возможности при уровне изоляции READ COMMITTED)*/

-- READ UNCOMMITTED
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
start transaction;
INSERT INTO type_podrazdelenia(id_type_podrazdelenia, name_type_podrazdelenia)
VALUES (10, 'цех');
INSERT INTO type_podrazdelenia (id_type_podrazdelenia, name_type_podrazdelenia)
VALUES (11, 'отделение');
rollback;

-- READ COMMITTED
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
start transaction;
INSERT INTO type_podrazdelenia(id_type_podrazdelenia, name_type_podrazdelenia)
VALUES (10, 'цех');
INSERT INTO type_podrazdelenia (id_type_podrazdelenia, name_type_podrazdelenia)
VALUES (11, 'отделение');
commit;


/* 7 задание (Продемонстрировать возможность записи в уже прочитанные данные при 
использовании уровня изоляции READ COMMITTED и отсутствие такой 
возможности при уровне изоляции REPEATABLE READ.)*/

-- READ COMMITTED
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
start transaction;
delete from type_podrazdelenia where id_type_podrazdelenia >= 10;
commit;

-- REPEATABLE READ
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
start transaction;
INSERT INTO type_podrazdelenia(id_type_podrazdelenia, name_type_podrazdelenia)
VALUES (10, 'цех');
INSERT INTO type_podrazdelenia (id_type_podrazdelenia, name_type_podrazdelenia)
VALUES (11, 'отделение');
commit;
