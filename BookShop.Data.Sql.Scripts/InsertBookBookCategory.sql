--Książki/Literatura piękna/Powieść społeczno-obyczajowa
if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Przeznaczeni' and ISBN like '9788308061633') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Powieść społeczno-obyczajowa' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Przeznaczeni' and ISBN like '9788308061633'), 
(select Id from BookCategory where NameForDisplay like 'Powieść społeczno-obyczajowa' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')));

if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Tajemniczy brat' and ISBN like '9788380694057') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Powieść społeczno-obyczajowa' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Tajemniczy brat' and ISBN like '9788380694057'), 
(select Id from BookCategory where NameForDisplay like 'Powieść społeczno-obyczajowa' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')));

if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Małe życie' and ISBN like '9788328026483') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Powieść społeczno-obyczajowa' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Małe życie' and ISBN like '9788328026483'), 
(select Id from BookCategory where NameForDisplay like 'Powieść społeczno-obyczajowa' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')));

if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Zanim się pojawiłeś' and ISBN like '9788380315884') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Powieść społeczno-obyczajowa' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Zanim się pojawiłeś' and ISBN like '9788380315884'), 
(select Id from BookCategory where NameForDisplay like 'Powieść społeczno-obyczajowa' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')));

if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Nadzieje i marzenia' and ISBN like '9788324041343') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Powieść społeczno-obyczajowa' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Nadzieje i marzenia' and ISBN like '9788324041343'), 
(select Id from BookCategory where NameForDisplay like 'Powieść społeczno-obyczajowa' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')));


--Książki/Literatura piękna/Sensacja, kryminał, thriller
if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Złudzenie' and ISBN like '9788379996551') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Sensacja, kryminał, thriller' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Złudzenie' and ISBN like '9788379996551'), 
(select Id from BookCategory where NameForDisplay like 'Sensacja, kryminał, thriller' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')));

if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Łaskun' and ISBN like '9788380693579') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Sensacja, kryminał, thriller' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Łaskun' and ISBN like '9788380693579'), 
(select Id from BookCategory where NameForDisplay like 'Sensacja, kryminał, thriller' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')));

if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'W objęciach nocy' and ISBN like '9788379432264') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Sensacja, kryminał, thriller' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'W objęciach nocy' and ISBN like '9788379432264'), 
(select Id from BookCategory where NameForDisplay like 'Sensacja, kryminał, thriller' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')));

if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Zemsta' and ISBN like '9788324036189') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Sensacja, kryminał, thriller' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Zemsta' and ISBN like '9788324036189'), 
(select Id from BookCategory where NameForDisplay like 'Sensacja, kryminał, thriller' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')));

if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Piętno Midasa' and ISBN like '9788380831377') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Sensacja, kryminał, thriller' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Piętno Midasa' and ISBN like '9788380831377'), 
(select Id from BookCategory where NameForDisplay like 'Sensacja, kryminał, thriller' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Książki')));


--Książki/Literatura faktu/Wspomnienia, dzienniki, listy
if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Grunt pod nogami' and ISBN like '9788327710376') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Wspomnienia, dzienniki, listy' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and 
m.NameForDisplay like 'Książki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Grunt pod nogami' and ISBN like '9788327710376'), 
(select Id from BookCategory where NameForDisplay like 'Wspomnienia, dzienniki, listy' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and 
m.NameForDisplay like 'Książki')));

if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Małe eksperymenty ze szczęściem' and ISBN like '9788379857432') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Wspomnienia, dzienniki, listy' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and 
m.NameForDisplay like 'Książki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Małe eksperymenty ze szczęściem' and ISBN like '9788379857432'), 
(select Id from BookCategory where NameForDisplay like 'Wspomnienia, dzienniki, listy' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and 
m.NameForDisplay like 'Książki')));

if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Okradziona z życia' and ISBN like '9788324158249') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Wspomnienia, dzienniki, listy' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and 
m.NameForDisplay like 'Książki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Okradziona z życia' and ISBN like '9788324158249'), 
(select Id from BookCategory where NameForDisplay like 'Wspomnienia, dzienniki, listy' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and 
m.NameForDisplay like 'Książki')));

if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Gdzie jest Julia?' and ISBN like '9788376426730') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Wspomnienia, dzienniki, listy' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and 
m.NameForDisplay like 'Książki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Gdzie jest Julia?' and ISBN like '9788376426730'), 
(select Id from BookCategory where NameForDisplay like 'Wspomnienia, dzienniki, listy' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and 
m.NameForDisplay like 'Książki')));

if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Beksiński - dzień po dniu kończącego się życia' and ISBN like '9788361443117') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Wspomnienia, dzienniki, listy' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and 
m.NameForDisplay like 'Książki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Beksiński - dzień po dniu kończącego się życia' and ISBN like '9788361443117'), 
(select Id from BookCategory where NameForDisplay like 'Wspomnienia, dzienniki, listy' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura faktu' and 
m.NameForDisplay like 'Książki')));

--Ebooki/Literatura piękna/Fantastyka
if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Rycerz Siedmiu Królestw' and ISBN like '9788377854167') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Fantastyka' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Ebooki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Rycerz Siedmiu Królestw' and ISBN like '9788377854167'), 
(select Id from BookCategory where NameForDisplay like 'Fantastyka' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Ebooki')));

--Ebooki/Literatura piękna/Romans
if not exists(select * from BookBookCategory where BookId = (select Id from Book where TitleForDisplay like 'Uwikłani Tom 1. Pokusa' and ISBN like '9788365170163') and 
BookCategoryId = (select Id from BookCategory where NameForDisplay like 'Romans' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Ebooki')))
insert into BookBookCategory(BookId, BookCategoryId) 
values((select Id from Book where TitleForDisplay like 'Uwikłani Tom 1. Pokusa' and ISBN like '9788365170163'), 
(select Id from BookCategory where NameForDisplay like 'Romans' and 
SubMainCategoryId = (select s.Id from SubMainCategory as s join MainCategory as m on s.MainCategoryId = m.Id where s.NameForDisplay like 'Literatura piękna' and 
m.NameForDisplay like 'Ebooki')));