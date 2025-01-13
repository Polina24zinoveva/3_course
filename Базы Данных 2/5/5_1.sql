-- Часть 1. Привилегии
-- 1) Создайте нового пользователя и предоставьте ему привилегии на выборку 
-- информации из созданных вами представлений и запуска процедур.
CREATE USER 'user_1' IDENTIFIED BY '12345';
GRANT SELECT ON accounting.sum_equipment_type_podrazdelenia TO 'user_1';
GRANT EXECUTE ON procedure horse_racing.task2 TO 'user_1';

-- 2) Соединитесь с СУБД от имени нового пользователя и проверьте возможность 
-- доступа к вашим данным через представления и запуск процедур.

-- 3) Проверьте невозможность доступа к вашим данным через таблицы и хранимые процедуры.

-- 4) Соединитесь с СУБД от своего имени и предоставьте новому пользователю привилегии на выборку, 
-- вставку, изменение и удаление данных из ваших таблиц.

GRANT SELECT ON horse_racing.jockey TO 'user_1'; 
GRANT INSERT ON horse_racing.jockey TO 'user_1'; 
GRANT UPDATE ON horse_racing.jockey TO 'user_1'; 
GRANT DELETE ON horse_racing.jockey TO 'user_1'; 

-- 5) Соединитесь с СУБД от имени нового пользователя и проверьте возможность 
-- изменения данных в созданных вами таблицах.

-- 6) Соединитесь с СУБД от своего имени и отберите у нового пользователя все предоставленные ему привилегии.
REVOKE SELECT ON accounting.sum_equipment_type_podrazdelenia FROM 'user_1';
REVOKE EXECUTE ON procedure horse_racing.task2 FROM 'user_1';
REVOKE SELECT ON horse_racing.jockey FROM 'user_1'; 
REVOKE INSERT ON horse_racing.jockey FROM 'user_1'; 
REVOKE UPDATE ON horse_racing.jockey FROM 'user_1'; 
REVOKE DELETE ON horse_racing.jockey FROM 'user_1'; 

SHOW GRANTS FOR 'user_1';


-- 7) Соединитесь с СУБД от имени нового пользователя и проверьте 
-- невозможность изменения данных в созданных Вами таблицах и запуск ваших хранимых процедур





-- Часть 2. Индексы
use sakila;
-- 1) Составляются и выполняются запросы:
-- a) Найти информацию по заданному исполнителю, используя его имя.
set profiling=1;
select * from actor where first_name = 'PENELOPE' and last_name='GUINESS';
show profiles;
-- 0.00262075


-- b) Найти всех участников указанного музыкального коллектива (по названию коллектива).
-- (Вывести всех актеров фильма)
set profiling=1;
select film.title as 'Фильм', actor.first_name as 'Фамилия актера, снимавшегося в этом фильме', 
actor.last_name as 'Имя актера, снимавшегося в этом фильме'
from film
join film_actor on film.film_id = film_actor.film_id
join actor on actor.actor_id = film_actor.actor_id
where film.title = 'ANALYZE HOOSIERS';
show profiles;
-- 0.01737050


-- c) Найти всех исполнителей, в описании (профиле) которых встречается указанное выражение,
-- с использованием полнотекстового запроса.
set profiling=1;
select * from actor
join film_actor on film_actor.actor_id = actor.actor_id
join film on film.film_id = film_actor.film_id
join film_category on film.film_id = film_category.film_id
join category on film_category.category_id = category.category_id
where category.name like 'Travel';
show profiles;
-- 0.04987000

-- 2) Оценивается время выполнения запросов. 
-- a) 0.00262075
-- b) 0.01737050
-- c) 0.04987000


-- 3) Анализируется план выполнения запросов. 
explain select * from actor where first_name = 'PENELOPE' and last_name='GUINESS';

explain select film.title as 'Фильм', actor.first_name as 'Фамилия актера, снимавшегося в этом фильме', 
actor.last_name as 'Имя актера, снимавшегося в этом фильме'
from film
join film_actor on film.film_id = film_actor.film_id
join actor on actor.actor_id = film_actor.actor_id
where film.title = 'ANALYZE HOOSIERS';

explain select * from actor
join film_actor on film_actor.actor_id = actor.actor_id
join film on film.film_id = film_actor.film_id
join film_category on film.film_id = film_category.film_id
join category on film_category.category_id = category.category_id
where category.name like 'Travel';

-- 4) Создаются необходимые индексы для повышения быстродействия запросов. Выполнение запроса должно 
-- исключать полное сканирование таблицы (отсутствие Table Scan в анализе запроса). 
create index index_info_name on actor(first_name, last_name);
-- drop index index_info_name on actor;

create index index_info_title on film(title);
-- drop index index_info_title on film;

create fulltext index index_full_text on category(name);
-- drop index index_full_text on category;

-- 5) Оценивается время выполнения тех же запросов при наличии созданных индексов. 
-- Запросы:
-- 1. Найти информацию по заданному исполнителю, используя его имя. 
-- 0.00262075 без индекса
set profiling=1;
select * from actor where first_name = 'PENELOPE' and last_name='GUINESS';
show profiles;
-- 0.00185625 с индексом

-- 2. Найти всех участников указанного музыкального коллектива (по названию коллектива). 
-- 0.01737050 без индекса
set profiling=1;
select film.title as 'Фильм', actor.first_name as 'Фамилия актера, снимавшегося в этом фильме', 
actor.last_name as 'Имя актера, снимавшегося в этом фильме'
from film
join film_actor on film.film_id = film_actor.film_id
join actor on actor.actor_id = film_actor.actor_id
where film.title = 'ANALYZE HOOSIERS';
show profiles;
-- 0.01014525 с индексом

-- 3. Найти все релизы заданного исполнителя и отсортировать их по дате выпуска. Вывести имя исполнителя, 
-- название релиза, дату выхода. 
set profiling=1;
select actor.first_name as 'Имя актера', actor.last_name as 'Фамилия актера', film.title as 'Фильмы, в которых снимался актёр HENRY BERRY:', film.release_year as 'Дата выхода'
from film 
join film_actor on film.film_id = film_actor.film_id
join actor on film_actor.actor_id = actor.actor_id
where actor.first_name = 'HENRY' 
and actor.last_name = 'BERRY'
order by film.release_year;
show profiles;
-- 0.00364525 с индексом


-- 4. Найти все главные релизы, выпущенные в указанный год, с указанием стиля релиза. 
-- Релиз является главным, если поле release.IS_MAIN_RELEASE = 1. 
-- 0.04805750 без индекса
create index index_full_release_year on film(release_year);
set profiling=1;
select film.title as 'Фильмы', film.release_year as 'Дата выхода', category.name as 'Жанр фильма'
from film 
join film_category on film.film_id = film_category.film_id
join category on film_category.category_id = category.category_id
where film.release_year = '2006';
show profiles;
-- 0.05650450 с индексом

-- 5. Найти всех исполнителей, в описании (профиле) которых встречается 
-- указанное выражение, с использованием полнотекстового запроса.
-- 0.04987000 без индекса
set profiling=1;
select * from actor
join film_actor on film_actor.actor_id = actor.actor_id
join film on film.film_id = film_actor.film_id
join film_category on film.film_id = film_category.film_id
join category on film_category.category_id = category.category_id
where match(category.name) against('Travel');
show profiles;
-- 0.04244300 с индексом
