-- задание 1
-- Создать триггер запрещающий вставку в таблицу новой строки с заданным параметром.
drop trigger if exists task1_1;
delimiter $
use horse_racing $
create trigger task1_1 before insert on horse
for each row
begin 
	if new.gender != 'м' and new.gender != 'ж' THEN
        signal sqlstate '45000'
        set message_text= 'Пол может быть только "м" или "ж"';
    end if;
end $

insert into horse values ('220', 'Рыжик', 'c', '6', '1003');
insert into horse values ('220', 'Рыжик', 'м', '6', '1003');

delete from horse where id_horse = 220;


-- Создать триггер заполняющий одно из полей таблицы на основе вводимых данных.
drop trigger if exists task1_2;
delimiter $
use horse_racing $
create trigger task1_2 before insert on competition
for each row
begin 
    set new.date = current_date();
end $

insert into competition values('20', '2024-02-01', '13:00', 'Красноярск', 'Забег');
select * from competition;
delete from competition where id_competition = 20;

-- задание 2
-- Создать триггер ведения аудита изменения записей в таблицах
drop table if exists horse_audit;
create table horse_audit (
    id_audit INT AUTO_INCREMENT PRIMARY KEY,
    id_horse INT,
    action VARCHAR(10),
    action_timestamp TIMESTAMP,
    changed_column VARCHAR(50),
    old_value VARCHAR(255),
    new_value VARCHAR(255)
);

drop trigger if exists task2;
delimiter $
use horse_racing $
create trigger task2 after update on horse
for each row
begin 
	if old.id_horse != new.id_horse then
        insert into horse_audit (id_horse, action, action_timestamp, changed_column, old_value, new_value)
		values (new.id_horse, 'UPDATE', NOW(), 'id_horse', old.id_horse, new.id_horse);
    end if;
    
    if old.nickname != new.nickname then
        insert into horse_audit (id_horse, action, action_timestamp, changed_column, old_value, new_value)
		values (new.id_horse, 'UPDATE', NOW(), 'nickname', old.nickname, new.nickname);
    end if;
    
    if old.gender != new.gender then
        insert into horse_audit (id_horse, action, action_timestamp, changed_column, old_value, new_value)
		values (new.id_horse, 'UPDATE', NOW(), 'gender', old.gender, new.gender);
	end if;
    
    if old.age != new.age then
        insert into horse_audit (id_horse, action, action_timestamp, changed_column, old_value, new_value)
		values (new.id_horse, 'UPDATE', NOW(), 'age', old.age, new.age);
    end if;
    
    if old.owher != new.owher then
		insert into horse_audit (id_horse, action, action_timestamp, changed_column, old_value, new_value)
		values (new.id_horse, 'UPDATE', NOW(), 'owher', old.owher, new.owher);
    end if;
	
end $

update horse set age = age + 1 where id_horse = 201;
select * from horse_audit;
update horse set age = age - 1 where id_horse = 201;
select * from horse_audit;

-- задание 3
-- Внести такие изменения в триггеры вставки и изменения записей таблиц, которые не позволят 
-- добавить или изменить записи с дублирующими названиями.

-- вставка записей таблиц
drop trigger if exists task3_1;
delimiter $
use horse_racing $
create trigger task3_1 before insert on horse
for each row
begin
    declare count int;

	select count(*) into count from horse where nickname = new.nickname;

	if count > 0 then
        signal sqlstate '45000'
        set message_text = 'Уже есть лошадь с токой кличкой';
    end if;
	
end $

insert into horse values ('220', 'Стрелка', 'м', '6', '1003');
insert into horse values ('220', 'Рыжик', 'м', '6', '1003');

delete from horse where id_horse = 220;


-- изменение записей таблиц
drop trigger if exists task3_2;
delimiter $
use horse_racing $
create trigger task3_2 before update on horse
for each row
begin
    declare count int;

	select count(*) into count from horse where nickname = new.nickname;

	if count > 0 then
        signal sqlstate '45000'
        set message_text = 'Уже есть лошадь с токой кличкой';
    end if;
	
end $

update horse set nickname = 'Стрелка' where id_horse = 203;
update horse set nickname = 'Рыжик' where id_horse = 203;
select * from horse;

update horse set nickname = 'Гром' where id_horse = 203;
select * from horse;



-- 4 задание
-- Создать новую таблицу или изменить существующую, добавив поле типа JSON, заполнить таблицу данными. 
-- Минимум одно из значений записи должно представлять из себя вложенную структуру, одно – массив.
drop table if exists horse_breeds;
create table horse_breeds(
	id int primary key,
    name_breeds varchar(45),
    json_description json
);
insert into horse_breeds values ('601', 'Мустанг', '{"Описание":"Одичавшая домашняя лошадь", "Рост":"140-150",
"Ареал":["Южная Америка","Северная Америка"], "В культуре":{"Книги":"Всадник без головы(1865)",
"Фильмы":"Спирит:душа прерий(2002)"}}');
insert into horse_breeds values ('602', 'Пони', '{"Описание":"Подвид домашней лошади", "Рост":"80-140",
"Ареал":["Северная Европа"], "В культуре":{"Мультфильм":"My little Pony"}}');
insert into horse_breeds values ('603', 'Орловский рысак', 
'{"Описание":"знаменитая русская порода легкоупряжных лошадей с наследственно закреплённой способностью к резвой рыси", 
"Рост":"160", "Ареал":["Россия", "Воронеж"], "В культуре":{"Книги":"Внук Тальони(1928)", 
"Картины":"Орловские рысаки в дышловой упряжке и собака(1861)", "Фильмы":"Крепыш(1982)", 
"Другое":"Марки"}}');
select * from horse_breeds;


-- 5 задание
-- Выполнить запрос, возвращающий содержимое данной таблицы, соответствующее некоторому условию, 
-- проверяющему значение атрибута вложенной структуры.
-- вывод пород лошадей, про которых есть книги
select * from horse_breeds where json_extract(json_description, '$."В культуре"."Книги"') IS NOT NULL;;

-- 6 задание
-- Выполнить запрос, изменяющий значение по некоторому существующему ключу в заданной строке таблицы.
update horse_breeds set json_description = json_set(json_description, '$."Рост"', '90-140') where id = 602;
select * from horse_breeds;
-- update horse_breeds set json_description = json_set(json_description, '$."Рост"', '80-140') where id = 602;
