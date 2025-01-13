:- use_module(library(http/http_server)).
:- use_module(library(http/http_dispatch)).
:- use_module(library(http/http_parameters)).
:- use_module(library(http/html_write)).
:- use_module(library(http/http_error)).
:- use_module(library(odbc)).

% библиотека для полного стектрейса ошибок
:- use_module(library(http/http_error)).

% хэндлер для корневой страницы
:- http_handler(root(.), home_page, []).
% хэндлер страницы для добавления нового требования
:- http_handler(root(add_requirements_page), add_requirements_page, []).
% хэндлер для добавления нового требования
:- http_handler(root(add_requirements), add_requirements, [method(post)]).
% хэндлер страницы для удаления требования
:- http_handler(root(delete_requirements_p), delete_requirements_p, []).
% хэндлер для удаления требования
:- http_handler(root(delete_requirements), delete_requirements, [method(post)]).
% хэндлер для ресета БД
:- http_handler(root(reset_DB), reset_DB, [method(post)]).

% Определение хэндлеров для различных запросов
:- http_handler(root(task_1), task_1_page, []).
:- http_handler(root(task_2), task_2_page, []).
:- http_handler(root(task_3), task_3_page, []).
:- http_handler(root(task_3_S), task_3_page_S, []).
:- http_handler(root(task_4), task_4_page, []).
:- http_handler(root(task_5), task_5_page, []).
:- http_handler(root(task_5_V), task_5_page_V, []).
:- http_handler(root(stop), stop, []).

% Запуск сервера
server(Port):- http_server(http_dispatch, [port(Port)]).
server:- server(8080).

% Остановка сервера
stop(Port):- http_stop_server(Port, http_dispatch).
stop:- stop(8080).


% Добавление в таблицу требование
insert_data_in_requirement(Education, Age, Gender, Language, Computer, Experience) :-
    connect_db(Connection),
    format(atom(Query), 'INSERT INTO Требование (образование, возраст, пол, владение_иностранными_языками, умение_работать_на_ПК, стаж) VALUES (''~w'', ~d, ''~w'', ''~w'', ''~w'', ~d)', [Education, Age, Gender, Language, Computer, Experience]),
    odbc_query(Connection, Query),
    odbc_disconnect(Connection).

% Добавление в таблицу соискатель
insert_data_in_seeker(Surname, Name, Requirement) :-
    connect_db(Connection),
    format(atom(Query), 'INSERT INTO Соискатель (фамилия, имя_отчество, соответствие_требованию) VALUES (''~w'', ''~w'', ~d)', [Surname, Name, Requirement]),
    odbc_query(Connection, Query),
    odbc_disconnect(Connection).

% Добавление в таблицу вакансия
insert_data_in_vacancy(Company, Vacancy, Salary, Requirement) :-
    connect_db(Connection),
    format(atom(Query), 'INSERT INTO Вакансия (название_предприятия, должность, ежемесячный_доход, требования_к_соискателю) VALUES (''~w'', ''~w'', ~d, ~d)', [Company, Vacancy, Salary, Requirement]),
    odbc_query(Connection, Query),
    odbc_disconnect(Connection).

% Добавление в таблицу список соискателей
insert_data_in_list_seekers(Vacancy, Seeker) :-
    connect_db(Connection),
    format(atom(Query), 'INSERT INTO Список_соискателей (вакансия, соискатель) VALUES (~d, ~d)', [Vacancy, Seeker]),
    odbc_query(Connection, Query),
    odbc_disconnect(Connection).




% Удаление из таблицы список соискателей
delete_all_data_from_list_seekers :-
    connect_db(Connection),
    odbc_query(Connection, 'DELETE FROM Список_соискателей', _),
    odbc_disconnect(Connection).

% Удаление из таблицы вакансия
delete_all_data_from_vacancy :-
    connect_db(Connection),
    odbc_query(Connection, 'DELETE FROM Вакансия', _),
    odbc_disconnect(Connection).

% Удаление из таблицы соискатель
delete_all_data_from_seeker :-
    connect_db(Connection),
    odbc_query(Connection, 'DELETE FROM Соискатель', _),
    odbc_disconnect(Connection).

% Удаление из таблицы требование
delete_all_data_from_requirement :-
    connect_db(Connection),
    odbc_query(Connection, 'DELETE FROM Требование', _),
    odbc_disconnect(Connection).


drop_tables :-
    connect_db(Connection),
	odbc_query(Connection, 'DROP TABLE IF EXISTS Список_соискателей', _),
    odbc_query(Connection, 'DROP TABLE IF EXISTS Вакансия', _),
    odbc_query(Connection, 'DROP TABLE IF EXISTS Соискатель', _),
    odbc_query(Connection, 'DROP TABLE IF EXISTS Требование', _),
    odbc_disconnect(Connection).




reset_DB(_):-
	drop_tables,

	create_table_requirements,
	create_table_job_seeker,
	create_table_job_vacancy,
	create_table_list_seekers,

    %инициализация БД
%	insert_data_in_requirement('Высшее', 35, 'Мужской', 'Да', 'Да', 3),
%    insert_data_in_requirement('Высшее', 35, 'Женский', 'Да', 'Да', 3),
%    insert_data_in_requirement('Высшее', 30, 'Мужской', 'Нет', 'Да', 2),
%    insert_data_in_requirement('Высшее', 25, 'Мужской', 'Да', 'Нет', 0),
%    insert_data_in_requirement('Высшее', 25, 'Женский', 'Да', 'Нет', 0),
%    insert_data_in_requirement('Среднее специальное', 25, 'Женский', 'Нет', 'Нет', 1),
%    insert_data_in_requirement('Среднее специальное', 20, 'Мужской', 'Нет', 'Нет', 0),
%    insert_data_in_requirement('Среднее специальное', 20, 'Женский', 'Нет', 'Нет', 0),

%	 insert_data_in_seeker('Петрова', 'А.К.', 8),
%    insert_data_in_seeker('Сидоров', 'М.А.', 4),
%    insert_data_in_seeker('Комарова', 'Д.Д.', 6),
%    insert_data_in_seeker('Смирнова', 'В.М.', 8),
%    insert_data_in_seeker('Александров', 'Р.Д.', 1),
%    insert_data_in_seeker('Зайцев', 'А.В.', 3),
%    insert_data_in_seeker('Никитина', 'В.Т.', 8),
%    insert_data_in_seeker('Григорьев', 'И.К.', 4),

%	 insert_data_in_vacancy('ЗИМ', 'Проектировщик', 50000, 3),
%    insert_data_in_vacancy('БКК', 'Кондитер', 40000, 6),
%    insert_data_in_vacancy('БКК', 'Продавец', 30000, 8),
%    insert_data_in_vacancy('Прогресс', 'Конструктор', 70000, 1),
%    insert_data_in_vacancy('Медгард', 'Терапевт', 40000, 4),
%    insert_data_in_vacancy('Ашан', 'Продавец', 30000, 8),

%    insert_data_in_list_seekers(1, 6),
%    insert_data_in_list_seekers(2, 3),
%    insert_data_in_list_seekers(3, 1),
%    insert_data_in_list_seekers(3, 7),
%   insert_data_in_list_seekers(4, 5),
%    insert_data_in_list_seekers(5, 2),
%    insert_data_in_list_seekers(5, 8),
%    insert_data_in_list_seekers(6, 1),
%    insert_data_in_list_seekers(6, 4),
%    insert_data_in_list_seekers(6, 7),





	insert_data_in_requirement('Higher', 35, 'Men', 'Yes', 'Yes', 5),
    insert_data_in_requirement('Higher', 35, 'Women', 'Yes', 'Yes', 3),
    insert_data_in_requirement('Higher', 30, 'Men', 'No', 'Yes', 2),
    insert_data_in_requirement('Higher', 25, 'Men', 'Yes', 'No', 0),
    insert_data_in_requirement('Higher', 25, 'Women', 'Yes', 'No', 0),
    insert_data_in_requirement('Secondary special', 25, 'Women', 'No', 'No', 1),
    insert_data_in_requirement('Secondary special', 20, 'Men', 'No', 'No', 0),
    insert_data_in_requirement('Secondary special', 20, 'Women', 'No', 'No', 0),

    insert_data_in_seeker('Petrova', 'A.K.', 8),
    insert_data_in_seeker('Sidorov', 'M.A.', 4),
    insert_data_in_seeker('Komarova', 'D.D.', 6),
    insert_data_in_seeker('Smirnova', 'V.M.', 8),
    insert_data_in_seeker('Aleksandrov', 'R.D.', 1),
    insert_data_in_seeker('Zaytcev', 'A.V.', 3),
    insert_data_in_seeker('Nikitina', 'B.T.', 8),
    insert_data_in_seeker('Grigorev', 'I.K.', 4),

    insert_data_in_vacancy('ZIM', 'Engineer', 50000, 3),
    insert_data_in_vacancy('BKK', 'Cook', 40000, 6),
    insert_data_in_vacancy('BKK', 'Salesman', 30000, 8),
    insert_data_in_vacancy('Progress', 'Designer', 70000, 1),
    insert_data_in_vacancy('Medgard', 'Therapist', 40000, 4),
    insert_data_in_vacancy('Ashan', 'Salesman', 30000, 8),

    insert_data_in_list_seekers(1, 6),
    insert_data_in_list_seekers(2, 3),
    insert_data_in_list_seekers(3, 1),
    insert_data_in_list_seekers(3, 7),
    insert_data_in_list_seekers(4, 5),
    insert_data_in_list_seekers(5, 2),
    insert_data_in_list_seekers(5, 8),
    insert_data_in_list_seekers(6, 1),
    insert_data_in_list_seekers(6, 4),
    insert_data_in_list_seekers(6, 7),


http_redirect(moved, '/', _Request).




% Предикат для получения строк таблицы требование
requirement_row([ID, Education, Age, Gender, Language, Computer, Experience]) :-
    odbc_query(dsn, 'SELECT * FROM Требование', row(ID, Education, Age, Gender, Language, Computer, Experience)).


% Предикат для записи строки таблицы требование в HTML
write_requirement_row([ID, Education, Age, Gender, Language, Computer, Experience]) :-
    format('<tr><td>~w</td><td>~w</td><td>~w</td><td>~w</td><td>~w</td><td>~w</td><td>~w</td></tr>', [ID, Education, Age, Gender, Language, Computer, Experience]).

generate_table_requirement :-
    format('<table border="1">'),
    format('<tr><th>ID</th><th>Образование</th><th>Возраст</th><th>Пол</th><th>Знание иностранного языка</th><th>Умение работать на ПК</th><th>Стаж</th></tr>'),
    forall(requirement_row(Row), write_requirement_row(Row)),
    format('</table>').


% соискатель
seeker_row([ID, Surname, Name, Requirement]) :-
    odbc_query(dsn, 'SELECT * FROM Соискатель', row(ID, Surname, Name, Requirement)).

write_seeker_row([ID, Surname, Name, Requirement]) :-
    format('<tr><td>~w</td><td>~w</td><td>~w</td><td>~w</td></tr>', [ID, Surname, Name, Requirement]).

generate_table_seeker :-
    format('<table border="1">'),
    format('<tr><th>ID</th><th>Фамилия</th><th>Имя Отчество</th><th>Требование</th></tr>'),
    forall(seeker_row(Row), write_seeker_row(Row)),
    format('</table>').




% вакансия
vacancy_row([ID, Company, Vacancy, Salary, Requirement]) :-
    odbc_query(dsn, 'SELECT * FROM Вакансия', row(ID, Company, Vacancy, Salary, Requirement)).

% Предикат для записи строки таблицы изданий в HTML
write_vacancy_row([ID, Company, Vacancy, Salary, Requirement]) :-
    format('<tr><td>~w</td><td>~w</td><td>~w</td><td>~w</td><td>~w</td></tr>', [ID, Company, Vacancy, Salary, Requirement]).

generate_table_vacancy :-
    format('<table border="1">'),
    format('<tr><th>ID</th><th>Компания</th><th>Вакансия</th><th>Зарплата</th><th>Требования</th></tr>'),
    forall(vacancy_row(Row), write_vacancy_row(Row)),
    format('</table>').



% список соискателей
% Предикат для получения строк таблицы связей книг и изданий
list_seekers_row([ID, VacancyID, SeekerID]) :-
    odbc_query(dsn, 'SELECT * FROM Список_соискателей', row(ID, VacancyID, SeekerID)).

% Предикат для записи строки таблицы связей книг и изданий в HTML
write_list_seekers_row([ID, VacancyID, SeekerID]) :-
    format('<tr><td>~w</td><td>~w</td><td>~w</td></tr>', [ID, VacancyID, SeekerID]).

generate_table_list_seekers :-
    format('<table border="1">'),
    format('<tr><th>ID</th><th>ID вакансии</th><th>ID соискателя</th></tr>'),
    forall(list_seekers_row(Row), write_list_seekers_row(Row)),
    format('</table>').



%Обработка главной страницы
home_page(_Request):-


    reply_html_page(
        title('Лабораторная работа 4. Выполнила Зиновьева Полина'),
        [
            h1('Лабораторная работа 4. Выполнила Зиновьева Полина'),
			h2('Поисковые запросы:'),
            ul([
                li(a([href('/task_1')], 'Найти должность, для которой существует максимальное число соискателей')),
                li(a([href('/task_2')], ' Найти все должности для мужчин, с высшим образованием и свободно владеющих иностранным языком')),
                li(a([href('/task_3')], 'Найти все предприятия, предлагающие доход выше указанного уровня')),
                li(a([href('/task_4')], 'Найти всех соискателей, умеющих работать на ПК, и имеющих стаж работы более 5 лет')),
                li(a([href('/task_5')], 'Подсчитать число предприятий, у которых есть заданная вакансия'))
            ])
        ]

    ),
	connect_db(_),
	format('<html><head><title>Биржа труда</title></head><body>'),
    format('<h2>Таблица требований</h2>'),
	generate_table_requirement,


	format('<form style="display: inline-block" method="post">'),
    format('<p><button type="submit" formaction="add_requirements_page">Добавить требование</button></p>'),
    format('</form>'),
    format('</body></html>'),

	format('<form style="display: inline-block" method="post">'),
    format('<p><button type="submit" formaction="delete_requirements_p">Удалить требование</button></p>'),
    format('</form>'),
    format('</body></html>'),

    format('<form style="display: inline-block" method="post">'),
    format('<p><button type="submit" formaction="reset_DB">Сбросить БД</button></p>'),
    format('</form>'),
    format('</body></html>'),


	format('<h2>Таблица соискателей</h2>'),
    generate_table_seeker,
	format('<h2>Таблица вакансий</h2>'),
    generate_table_vacancy,
	format('<h2>Таблица списков соискателей</h2>'),
    generate_table_list_seekers,
	format('</body></html>').



%Реализовать следующие типы запросов:

%1. Найти должность, для которой существует максимальное число соискателей;

task_1(Vacancys) :-
    connect_db(Connection),
        atomic_list_concat(['SELECT "Вакансия"."id", "Вакансия"."название_предприятия", "Вакансия"."должность"
        FROM "Список_соискателей"
		JOIN "Вакансия" ON "Список_соискателей"."вакансия" = "Вакансия"."id"
		GROUP BY "Вакансия"."id", "Вакансия"."название_предприятия", "Вакансия"."название_предприятия"
		HAVING COUNT(*) = (
			SELECT MAX("cnt")
			FROM (
				SELECT COUNT(*) AS "cnt"
				FROM "Список_соискателей"
				GROUP BY "вакансия"
			) AS "max_count"
		)
        LIMIT 1'], Query),
    findall([ID, Company, Vacancy], odbc_query(Connection, Query, row(ID, Company, Vacancy)), Vacancys),
    odbc_disconnect(Connection).

print_vacancy([]).
print_vacancy([[ID, Company, Vacancy]|Rest]) :-
	format('<tr><td>~w</td><td>~w</td><td>~w</td></tr>', [ID, Company, Vacancy]),
	print_vacancy(Rest).


task_1_page(_Request):-
    task_1(Vacancys),
	format('Content-type: text/html; charset=UTF-8~n~n', []),
	format('<html><head><h3>Должность, для которой существует максимальное число соискателей:</h3></head><body>', []),
	format('<table border="1">'),
	format('<tr><th>ID</th><th> Компания</th><th> Вакансия</th></tr>'),
	print_vacancy(Vacancys),
	format('</table>'),
	format('<form style="display: inline-block;"><p><button type="submit" formaction="/">На главный экран</button></p></form></body></html>', []).




task_2(Vacancys) :-
	connect_db(Connection),
    format(atom(Query), 'select Вакансия.id, Вакансия.название_предприятия, Вакансия.должность from Вакансия
		join Требование on Вакансия.требования_к_соискателю = Требование.id
		where Требование.пол = ''~w'' and Требование.образование = ''~w''
		and Требование.владение_иностранными_языками = ''~w''', ['Men', 'Higher', 'Yes']),
    findall([ID, Company, Vacancy], odbc_query(Connection, Query, row(ID, Company, Vacancy)), Vacancys),
    odbc_disconnect(Connection).


task_2_page(_Request):-

    task_2(Vacancys),
	format('Content-type: text/html; charset=UTF-8~n~n', []),
    format('<p>Должности для мужчин, с высшим образованием и свободно владеющих иностранным языком:</p>'),
	format('<table border="1">'),
	format('<tr><th>ID</th><th> Компания</th><th> Вакансия</th></tr>'),
	print_vacancy(Vacancys),
	format('</table>'),
	format('<form style="display: inline-block;"><p><button type="submit" formaction="/">На главный экран</button></p></form></body></html>', []).




%task_2(Vacancys) :-
%	connect_db(Connection),
%    format(atom(Query), 'select "Вакансия"."id", "Вакансия"."название_предприятия", "Вакансия"."должность" from "Вакансия"%
%		join "Требование" on "Вакансия"."требования_к_соискателю" = "Требование"."id"
%		where "Требование"."пол" = ''~w'' and "Требование"."образование" = ''~w''
%		and "Требование"."владение_иностранными_языками" = ''~w''', ['Men', 'Higher', 'Yes']),
%        odbc_query(Connection, Query, Rows),
%    odbc_disconnect(Connection),
%    findall(Vacanci, member(row(Vacanci), Rows), Vacancys).


%task_2_page(_Request):-
%
%    task_2(Vacancys),
%	format('Content-type: text/html; charset=UTF-8~n~n', []),
%
%	format('<html><head><title>Найти все книги заданного автора</title></head><body>', []),
%    format('<p>Должности для мужчин, с высшим образованием и свободно владеющих иностранным языком:</p>'),
%	forall(member([ID, Company, Vacancy], Vacancys), print_vacancy_task2([ID, Company, Vacancy])),
%	format('<form style="display: inline-block;"><p><button type="submit" formaction="/">На главный экран</button></p></form></body></html>', []).


%print_vacancy_task2([ID, Company, Vacancy]) :-
%    format('<tr><td>~w</td><td>~w</td><td>~w</td></tr>', [ID, Company, Vacancy]).




%3. Найти все предприятия, предлагающие доход выше указанного уровня;
task_3(S, Companies) :-
	connect_db(Connection),
    format(atom(Query), 'select id, название_предприятия, ежемесячный_доход from Вакансия
		where ежемесячный_доход >= ''~w''', [S]),
    findall([ID, Company, Salary], odbc_query(Connection, Query, row(ID, Company, Salary)), Companies),
    odbc_disconnect(Connection).


task_3_page(_Request):-
    reply_html_page(
        title('Предприятия, предлагающие доход выше указанного уровня'),
        [form(
            [action=location_by_id(task_3_page_S), method(post)],
            [
                table([
                    tr([th('Введите доход:'), td(input([name(sal)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='Искать'])))
                ] )
            ]
        )]
    ).

task_3_page_S(Request):-
	http_parameters(
			Request,
			[sal(S, [])]
	  ),
	% Преобразование S в число
    atom_number(S, SNum),
	task_3(SNum, Companies),

	format('Content-type: text/html; charset=UTF-8~n~n', []),
    format('<p>Предприятия, предлагающие доход выше указанного уровня:</p>'),
	format('<table border="1">'),
	format('<tr><th>ID</th><th> Компания</th><th> Доход</th></tr>'),
	print_companies(Companies),
	format('</table>'),
	format('<form style="display: inline-block;"><p><button type="submit" formaction="/">На главный экран</button></p></form></body></html>', []).


print_companies([]).
print_companies([[ID, Company, Salary]|Rest]) :-
	format('<tr><td>~w</td><td>~w</td><td>~w</td></tr>', [ID, Company, Salary]),
	print_companies(Rest).




% 4. Найти всех соискателей, умеющих работать на ПК, и имеющих стажработы более 5 лет;
task_4(Seekers) :-
	connect_db(Connection),
    format(atom(Query), 'SELECT Соискатель.id, Соискатель.фамилия, Соискатель.имя_отчество FROM Соискатель
	JOIN Требование ON Соискатель.соответствие_требованию = Требование.id where  Требование.умение_работать_на_ПК = ''~w''
	and Требование.стаж >= 5', ['Yes']),
    findall([ID, LastName, FirstName], odbc_query(Connection, Query, row(ID, LastName, FirstName)), Seekers),
    odbc_disconnect(Connection).


print_seekers([]).
print_seekers([[ID, LastName, FirstName]|Rest]) :-
	format('<tr><td>~w</td><td>~w</td><td>~w</td></tr>', [ID, LastName, FirstName]),
	print_seekers(Rest).


task_4_page(_Request):-
    task_4(Seekers),
	format('Content-type: text/html; charset=UTF-8~n~n', []),
    format('<p>Соискатели, умеющие работать на ПК, и имеющие стаж работы более 5 лет:</p>'),
	format('<table border="1">'),
	format('<tr><th>ID</th><th> Фамилия</th><th> Имя,Отчество</th></tr>'),
	print_seekers(Seekers),
	format('</table>'),
	format('<form style="display: inline-block;"><p><button type="submit" formaction="/">На главный экран</button></p></form></body></html>', []).



%5. Подсчитать число предприятий, у которых есть заданная вакансия.
task_5(Vacanci, Count) :-
    connect_db(Connection),
    format(atom(Query), 'select count(*) from Вакансия
	group by должность
	having должность =  ''~w''', [Vacanci]),
    odbc_query(Connection, Query, row(Count)),
    odbc_disconnect(Connection).


task_5_page(_Request):-
    reply_html_page(
        title('Число предприятий, у которых есть заданная вакансия'),
        [form(
            [action=location_by_id(task_5_page_V), method(post)],
            [
                table([
                    tr([th('Введите вакансию:'), td(input([name(vacancy)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='Искать'])))
                ] )
            ]
        )]
    ).

task_5_page_V(Request):-
	http_parameters(
		Request,
		[vacancy(Vacanci, [])]
	),
    task_5(Vacanci, Count),
    reply_html_page(
        title('Число предприятий, у которых есть вакансия:'),
        [h3('Число предприятий, у которых есть вакансия::'), p(Count),
         form(
                [style('display: inline-block')],
                p(button([type(submit), formaction('/')], 'На главный экран'))
            )]
    ).


%Страница с добавлением новой вакансии
add_requirements_page(_Request):-
    reply_html_page(
        title('Добавление требование'),
        [form(
            [action=location_by_id(add_requirements), method(post)],
            [
                h3('Добавление требования:'),
                table([
                    tr([th('Образование'), td(input([name(education)]))]),
                    tr([th('Возраст'), td(input([name(age)]))]),
                    tr([th('Пол'), td(input([name(gender)]))]),
                    tr([th('Знание иностранного языка'), td(input([name(language)]))]),
                    tr([th('Умение работать на ПК'), td(input([name(computer)]))]),
                    tr([th('Опыт'), td(input([name(experience)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='Добавить'])))
                ])
            ]
        )]
    )
.

%Добавление требования
add_requirements(Request):-
    http_parameters(
        Request,
        [
            education(Education, []),
            age(Age, []),
            gender(Gender, []),
            language(Language, []),
            computer(Computer, []),
            experience(Experience, [])
        ]
    ),
    atom_number(Age, AgeNum),
    atom_number(Experience, ExperienceNum),
    connect_db(Connection),
	format(atom(Query), 'INSERT INTO Требование (образование, возраст, пол, владение_иностранными_языками, умение_работать_на_ПК, стаж)
	VALUES (''~w'', ~d, ''~w'', ''~w'', ''~w'', ~d)', [Education, AgeNum, Gender, Language, Computer, ExperienceNum]),
    odbc_query(Connection, Query),
    odbc_disconnect(Connection),
    http_redirect(moved, '/', Request).


%Страница с удалением вакансии
delete_requirements_p(_Request):-
    reply_html_page(
        title('Удаление требование'),
        [form(
            [action=location_by_id(delete_requirements), method(post)],
            [
                h3('Удаление требования:'),
                table([
                    tr([th('Образование'), td(input([name(education)]))]),
                    tr([th('Возраст'), td(input([name(age)]))]),
                    tr([th('Пол'), td(input([name(gender)]))]),
                    tr([th('Знание иностранного языка'), td(input([name(language)]))]),
                    tr([th('Умение работать на ПК'), td(input([name(computer)]))]),
                    tr([th('Опыт'), td(input([name(experience)]))]),
                    tr(td([colspan(2), align(right)], input([type=submit, value='Удалить'])))
                ])
            ]
        )]
    ).


%Удаление требования
delete_requirements(Request):-
    http_parameters(
        Request,
        [
            education(Education, []),
            age(Age, []),
            gender(Gender, []),
            language(Language, []),
            computer(Computer, []),
            experience(Experience, [])
          ]
    ),
    atom_number(Age, AgeNum),
    atom_number(Experience, ExperienceNum),

	connect_db(Connection),
    format(atom(Query), 'DELETE FROM Требование WHERE образование = ''~w'' AND возраст = ''~d''  AND пол = ''~w'' AND
	владение_иностранными_языками = ''~w'' AND умение_работать_на_ПК = ''~w'' AND стаж = ''~d'' ', [Education, AgeNum, Gender, Language, Computer, ExperienceNum]),
    odbc_query(Connection, Query),
    odbc_disconnect(Connection),
    http_redirect(moved, '/', Request).


%коннект к БД
connect_db(Connection):-
    odbc_connect(
        'swi',
        Connection,
        [
            user(postgres),
            password(password),
            alias(dsn),
            open(once)
        ]
    ).


% Создание таблицы c требованиями
    create_table_requirements :-
        connect_db(_),
        odbc_query(
            dsn,
            '
            CREATE TABLE Требование (
            id SERIAL PRIMARY KEY,
            образование VARCHAR(50),
            возраст INT,
            пол VARCHAR(10),
            владение_иностранными_языками VARCHAR(50),
            умение_работать_на_ПК VARCHAR(50),
            стаж INT)
        '), odbc_disconnect(dsn).

    % Создание таблицы c соискателями
    create_table_job_seeker :-
        connect_db(_),
        odbc_query(
            dsn,
            '
            CREATE TABLE Соискатель (
            id SERIAL PRIMARY KEY,
            фамилия VARCHAR(50),
            имя_отчество VARCHAR(50),
            соответствие_требованию INT,
            FOREIGN KEY (соответствие_требованию) REFERENCES Требование(id))
        '), odbc_disconnect(dsn).

    % Создание таблицы c вакансиями
    create_table_job_vacancy :-
        connect_db(_),
        odbc_query(
            dsn,
            '
            CREATE TABLE Вакансия (
            id SERIAL PRIMARY KEY,
            название_предприятия VARCHAR(50),
            должность VARCHAR(50),
            ежемесячный_доход INT,
            требования_к_соискателю INT,
            FOREIGN KEY (требования_к_соискателю) REFERENCES Требование(id))
        '), odbc_disconnect(dsn).

    % Создание таблицы список соискателей
    create_table_list_seekers :-
        connect_db(_),
        odbc_query(
            dsn,
            '
            CREATE TABLE Список_соискателей (
            id SERIAL PRIMARY KEY,
            вакансия INT,
            соискатель INT,
            FOREIGN KEY (вакансия) REFERENCES Вакансия(id),
            FOREIGN KEY (соискатель) REFERENCES Соискатель(id))
        '), odbc_disconnect(dsn).


% Удаление из таблицы список соискателей
delete_data_from_list_seekers(Id) :-
    connect_db(Connection),
    format(atom(Query), 'DELETE FROM Список_соискателей WHERE id = (~d)', [Id]),
    odbc_query(Connection, Query),
    odbc_disconnect(Connection).

% Удаление из таблицы вакансия
delete_data_from_vacancy(Id) :-
    connect_db(Connection),
    format(atom(Query), 'DELETE FROM Вакансия WHERE id = (~d)', [Id]),
    odbc_query(Connection, Query),
    odbc_disconnect(Connection).

% Удаление из таблицы соискатель
delete_data_from_seeker(Id) :-
    connect_db(Connection),
    format(atom(Query), 'DELETE FROM Соискатель WHERE id = (~d)', [Id]),
    odbc_query(Connection, Query),
    odbc_disconnect(Connection).

% Удаление из таблицы требование
delete_data_from_requirement(Id) :-
    connect_db(Connection),
    format(atom(Query), 'DELETE FROM Требование  WHERE id = (~d)', [Id]),
    odbc_query(Connection, Query),
    odbc_disconnect(Connection).


