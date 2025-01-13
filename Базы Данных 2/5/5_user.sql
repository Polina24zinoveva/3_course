-- 2) Соединитесь с СУБД от имени нового пользователя и проверьте возможность 
-- доступа к вашим данным через представления и запуск процедур.
use accounting;
select * from sum_equipment_type_podrazdelenia;

use horse_racing;
call task2();


-- 3) Проверьте невозможность доступа к вашим данным через таблицы и хранимые процедуры.
use accounting;
select * from equipment;

use horse_racing;
call task3();



-- 5) Соединитесь с СУБД от имени нового пользователя и проверьте возможность 
-- изменения данных в созданных вами таблицах.
select * from jockey;
insert into jockey values('2020', 'Ивано', 'Иваново', '20', 5);
update jockey set id_jockey = '2100' where id_jockey = '2020';
delete from jockey where id_jockey = '2100';


-- 7) Соединитесь с СУБД от имени нового пользователя и проверьте 
-- невозможность изменения данных в созданных Вами таблицах и запуск ваших хранимых процедур

use accounting;
select * from sum_equipment_type_podrazdelenia;

use horse_racing;
call task2();
select * from jockey;
insert into jockey values('2020', 'Ивано', 'Иваново', '20', 5);
update jockey set id_jockey = '2100' where id_jockey = '2020';
delete from jockey where id_jockey = '2100';

