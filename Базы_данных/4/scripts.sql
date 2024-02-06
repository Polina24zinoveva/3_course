use sakila;
select * from actor;
select * from address;
select * from category;
select * from city;
select * from country;
select * from customer;
select * from film;
select * from film_actor;
select * from film_category;
select * from film_text;
select * from inventory;
select * from language;
select * from payment;
select * from rental;
select * from staff;
select * from store;



-- 1 задание (покупатели из указанного списка стран)
select customer.first_name as 'Имя покупателя', customer.last_name as 'Фамилия покупателя', country.country as 'Страна'
from customer 
join address on customer.address_id = address.address_id
join city on address.city_id = city.city_id
join country on city.country_id = country.country_id
where country in ('Poland', 'Spain', 'Russian Federation');


-- 2 задание(фильмы, в которых снимался указанный актер)
select film.title as 'Фильмы, в которых снимался актёр HENRY BERRY:', category.name as 'Жанр фильма', actor.first_name as 'Имя актера', actor.last_name as 'Фамилия актера'
from film 
join film_category on film.film_id = film_category.film_id
join category on film_category.category_id = category.category_id
join film_actor on film.film_id = film_actor.film_id
join actor on film_actor.actor_id = actor.actor_id
where actor.first_name = 'HENRY' 
and actor.last_name = 'BERRY';


-- 3 задание(топ 10 жанров фильмов по величине дохода в указанном месяце)
select category.name as 'Категория фильма, входящего в топ 10 по величине дохода в июне 2006', 
sum(payment.amount) as 'Доход фильма'
from category 
join film_category on category.category_id = film_category.category_id
join film on film_category.film_id = film.film_id
join inventory on film.film_id = inventory.film_id
join rental on inventory.inventory_id = rental.inventory_id
join payment on rental.rental_id = payment.rental_id
where payment.payment_date like '2005-06-%'
group by category.category_id
order by sum(payment.amount) desc
limit 10;


-- 4 задание(список из 5 клиентов, упорядоченный по количеству купленных фильмов с указанным актером, начиная с 10-й позиции: отобразить имя, фамилию, количество купленных фильмов.)
select customer.first_name as 'Имя', customer.last_name as 'Фамилия', count(*) as 'Количество купленных фильмов с участием актера HENRY BERRY'
from customer
join rental on customer.customer_id = rental.customer_id
join inventory on rental.inventory_id = inventory.inventory_id
join film on inventory.film_id = film.film_id
join film_actor on film.film_id = film_actor.film_id
join actor on film_actor.actor_id = actor.actor_id
where actor.first_name = 'HENRY' 
and actor.last_name = 'BERRY'
group by customer.customer_id
order by count(*) desc
limit 5 offset 10;



-- 5 задание(Вывести для каждого магазина его город, страну расположения и суммарный доход за первую неделю продаж)
select * from payment order by payment_date;

select DISTINCT store.store_id as 'ID_магазина', city.city as 'Город', country.country as 'Страна', sum(payment.amount) as 'Доход за первую неделю продаж'
from store
join staff on store.store_id = staff.store_id
join address on staff.address_id = address.address_id
join city on address.city_id = city.city_id
join country on city.country_id = country.country_id
join payment on staff.staff_id = payment.staff_id
where payment_date < (select date_add(min(payment_date), interval 1 week) FROM payment)
group by store.store_id, city.city, country.country;

-- 6 задание(Вывести всех актеров для фильма, принесшего наибольший доход)
select film.title as 'Фильм, принесший наибольший доход', actor.first_name as 'Фамилия актера, снимавшегося в этом фильме', 
actor.last_name as 'Имя актера, снимавшегося в этом фильме'
from film
join film_actor on film.film_id = film_actor.film_id
join actor on actor.actor_id = film_actor.actor_id
where film.title = (select film.title from film
	join inventory on film.film_id = inventory.film_id
	join rental on inventory.inventory_id = rental.inventory_id
	join payment on rental.rental_id = payment.rental_id
    group by film.film_id
	order by sum(payment.amount) desc
	limit 1);


-- 7 задание(Для всех покупателей вывести информацию о покупателях и актерах-однофамильцах)
select distinct customer.first_name, customer.last_name, actor.first_name, actor.last_name
from customer
left join actor on customer.last_name = actor.last_name; 

-- 8 задание(Для всех актеров вывести информацию о покупателях и актерах-однофамильцах)
select distinct customer.first_name, customer.last_name, actor.first_name, actor.last_name
from customer
right join actor on customer.last_name = actor.last_name; 

-- 9 задание
select length as 'Значение характеристики', count(*) as 'Количество фильмов с таким значением характеристики' from film 
where length = (select max(length) from film)
group by length
union
select length, count(*) from film 
where length = (select min(length) from film)
group by length
union
select count(*), max(actor_count)
from (select count(*) as actor_count, film_id
	from film_actor
    group by film_id
    having actor_count = 
		(select count(*) from film_actor
		group by film_actor.film_id
		order by count(*) desc limit 1))
	AS films_with_max_actors
union 
select count(*), min(actor_count)
from (select count(*) as actor_count, film_id
	from film_actor
    group by film_id
    having actor_count = 
		(select count(*) from film_actor
		group by film_actor.film_id
		order by count(*) limit 1))
	AS films_with_min_actors;


/*-- максимальное количество актеров в фильме
select count(*) from film_actor
	group by film_actor.film_id
	order by count(*) desc limit 1;
    
-- количество актеров в фильме
select count(*) from film_actor
	group by film_actor.film_id;


select count(*), max(actor_count)
from (select count(*) as actor_count, film_id
	from film_actor
    group by film_id
    having actor_count = 
		(select count(*) from film_actor
		group by film_actor.film_id
		order by count(*) desc limit 1))
	AS films_with_max_actors;*/
