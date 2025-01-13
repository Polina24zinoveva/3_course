-- задание 1
-- добавление лет к возрасту лошадей
delimiter $
use horse_racing $
create procedure task1(a int)
begin
	select id_horse, age from horse;
	update horse set age = age + a where id_horse > 0;
	select id_horse, age from horse;
end $
-- drop procedure task1;

call task1(1);

-- убавление лет возраста лошадей
create procedure anti_task1(a int)
begin
	select id_horse, age from horse;
	update horse set age = age - a where id_horse > 0;
	select id_horse, age from horse;
end $

call anti_task1(1);

-- задание 2
-- информация о лошади и его хозяине
delimiter $
use horse_racing $
create procedure task2()
begin
	select horse.id_horse, horse.nickname, horse_owher.name, horse_owher.id_owher 
    from horse
    join horse_owher on horse.owher = horse_owher.id_owher;
end $

call task2();

-- задание 3
-- Максимальный, минимальный и средний возраст лошадей
delimiter $
use horse_racing $
create procedure task3()
begin
	select max(age) as "Максимальный, минимальный и средний возраст лошадей" from horse 
    union
    select min(age) from horse 
    union
    select avg(age) from horse;
end $

call task3();

-- задание 4
-- добавила к таблице competition графу день недели
delimiter $
use horse_racing $
create procedure task4()
begin
	select id_competition, date, 
	case 
		when WEEKDAY(date) = 0 then 'Понедельник'
		when WEEKDAY(date) = 1 then 'Вторник'
		when WEEKDAY(date) = 2 then 'Среда'
		when WEEKDAY(date) = 3 then 'Четверг'
		when WEEKDAY(date) = 4 then 'Пятница'
		when WEEKDAY(date) = 5 then 'Суббота'
		when WEEKDAY(date) = 6 then 'Воскресенье'
		else null
	end as "День недели",
	time, location, name_competition
	from competition;
end $

call task4();

-- 5 задание
drop procedure if exists task5;
delimiter $
use horse_racing $
create procedure task5(r int)
begin
	DECLARE done INT DEFAULT FALSE;
    DECLARE jockey_id_jockey INT;
    DECLARE jockey_name VARCHAR(45);
    DECLARE jockey_address VARCHAR(45);
    DECLARE jockey_age INT;
    DECLARE jockey_rating INT;
    
    -- объявление курсора для выборки записей, удовлетворяющих условию
    DECLARE jockey_cursor CURSOR FOR 
        select id_jockey, name, address, age, rating 
        from jockey 
        where rating >= r; 
        
	-- указываем, что после выполнения курсора выход из цикла
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

    -- открываем курсор
    open jockey_cursor;
    
		-- читаем данные из курсора, пока есть записи
		read_loop: loop
			-- получаем данные из курсора в переменные
			fetch jockey_cursor into jockey_id_jockey, jockey_name, jockey_address, jockey_age, jockey_rating;
			
            -- если записей больше нет, выходим из цикла
			if done then
				leave read_loop;
			end if;
            
			-- выводим данные
			select jockey_id_jockey, jockey_name, jockey_address, jockey_age, jockey_rating;
		end loop;
        
    -- закрываем курсор
    close jockey_cursor;
end $
call task5(4);


-- задание 6
drop procedure if exists task6;
delimiter $
use horse_racing $
create procedure task6(r int)
begin
	DECLARE done INT DEFAULT FALSE;
    DECLARE jockey_id_jockey INT;
    DECLARE jockey_name VARCHAR(45);
    DECLARE jockey_address VARCHAR(45);
    DECLARE jockey_age INT;
    DECLARE jockey_rating INT;
    
    -- объявление курсора для выборки записей, удовлетворяющих условию
    DECLARE jockey_cursor CURSOR FOR 
        select id_jockey, name, address, age, rating 
        from jockey 
        where rating >= r; 
        
	-- указываем, что после выполнения курсора выход из цикла
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
	-- создание таблицы task6, если она не существует
    CREATE TABLE IF NOT EXISTS task6 (
        jockey_id INT,
        jockey_name VARCHAR(45),
        jockey_address VARCHAR(45),
        jockey_age INT,
        jockey_rating INT
    );
    
    -- открываем курсор
    open jockey_cursor;
		-- читаем данные из курсора, пока есть записи
		read_loop: loop
			-- получаем данные из курсора в переменные
			fetch jockey_cursor into jockey_id_jockey, jockey_name, jockey_address, jockey_age, jockey_rating;
			
            -- если записей больше нет, выходим из цикла
			if done then
				leave read_loop;
			end if;
            
            -- если записи есть;
			insert into task6
			values (jockey_id_jockey, jockey_name, jockey_address, jockey_age, jockey_rating);
		end loop;
        
    -- закрываем курсор
    close jockey_cursor;
    -- вывод таблицы
	select * from task6;
end $

call task6(4);
