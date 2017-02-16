--Książki/Literatura piękna
if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Przeznaczeni' and ISBN like '9788308061633') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Przeznaczeni' and ISBN like '9788308061633'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Tajemniczy brat' and ISBN like '9788380694057') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Tajemniczy brat' and ISBN like '9788380694057'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Małe życie' and ISBN like '9788328026483') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Małe życie' and ISBN like '9788328026483'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Zanim się pojawiłeś' and ISBN like '9788380315884') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Zanim się pojawiłeś' and ISBN like '9788380315884'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Nadzieje i marzenia' and ISBN like '9788324041343') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Nadzieje i marzenia' and ISBN like '9788324041343'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Złudzenie' and ISBN like '9788379996551') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Złudzenie' and ISBN like '9788379996551'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Łaskun' and ISBN like '9788380693579') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Łaskun' and ISBN like '9788380693579'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'W objęciach nocy' and ISBN like '9788379432264') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'W objęciach nocy' and ISBN like '9788379432264'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Zemsta' and ISBN like '9788324036189') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Zemsta' and ISBN like '9788324036189'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Piętno Midasa' and ISBN like '9788380831377') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Piętno Midasa' and ISBN like '9788380831377'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));


--Książki/Literatura faktu
if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Grunt pod nogami' and ISBN like '9788327710376') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura faktu' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Grunt pod nogami' and ISBN like '9788327710376'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura faktu' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Małe eksperymenty ze szczęściem' and ISBN like '9788379857432') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura faktu' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Małe eksperymenty ze szczęściem' and ISBN like '9788379857432'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura faktu' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Okradziona z życia' and ISBN like '9788324158249') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura faktu' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Okradziona z życia' and ISBN like '9788324158249'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura faktu' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Gdzie jest Julia?' and ISBN like '9788376426730') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura faktu' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Gdzie jest Julia?' and ISBN like '9788376426730'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura faktu' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Beksiński - dzień po dniu kończącego się życia' and ISBN like '9788361443117') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura faktu' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Beksiński - dzień po dniu kończącego się życia' and ISBN like '9788361443117'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura faktu' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));


--Książki/Książki naukowe i popularnonaukowe
if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'La Santa Muerte' and ISBN like '9788365442284') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Książki naukowe i popularnonaukowe' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'La Santa Muerte' and ISBN like '9788365442284'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Książki naukowe i popularnonaukowe' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Boska bez włoska' and ISBN like '9788365506382') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Książki naukowe i popularnonaukowe' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Boska bez włoska' and ISBN like '9788365506382'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Książki naukowe i popularnonaukowe' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Ukryte terapie' and ISBN like '9788394078317') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Książki naukowe i popularnonaukowe' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Ukryte terapie' and ISBN like '9788394078317'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Książki naukowe i popularnonaukowe' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Królowa' and ISBN like '9788365521385') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Książki naukowe i popularnonaukowe' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Królowa' and ISBN like '9788365521385'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Książki naukowe i popularnonaukowe' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Książki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Rycerz Siedmiu Królestw' and ISBN like '9788377854167') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Ebooki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Rycerz Siedmiu Królestw' and ISBN like '9788377854167'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Ebooki'))));

if not exists(select * from BookSubMainCategory where BookId = (select Id from Book where TitleForDisplay like 'Uwikłani Tom 1. Pokusa' and ISBN like '9788365170163') and 
SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Ebooki')))
insert into BookSubMainCategory(BookId, SubMainCategoryId) 
values((select Id from Book where TitleForDisplay like 'Uwikłani Tom 1. Pokusa' and ISBN like '9788365170163'), 
(select SubMainCategoryId = (select Id from SubMainCategory where NameForDisplay like 'Literatura piękna' and 
MainCategoryId = (select Id from MainCategory where NameForDisplay like 'Ebooki'))));