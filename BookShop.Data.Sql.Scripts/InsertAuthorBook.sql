if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Katarzyna' and LastNameForDisplay like 'Grochola') and 
BookId = (select Id from Book where TitleForDisplay like 'Przeznaczeni' and ISBN like '9788308061633'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Katarzyna' and LastNameForDisplay like 'Grochola'), (select Id from Book where TitleForDisplay like 'Przeznaczeni'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Virginia C.' and LastNameForDisplay like 'Andrews') and 
BookId = (select Id from Book where TitleForDisplay like 'Tajemniczy brat' and ISBN like '9788380694057'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Virginia C.' and LastNameForDisplay like 'Andrews'), (select Id from Book where TitleForDisplay like 'Tajemniczy brat' and 
ISBN like '9788380694057'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Yanagihara' and LastNameForDisplay like 'Hanya') and 
BookId = (select Id from Book where TitleForDisplay like 'Małe życie' and ISBN like '9788328026483'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Yanagihara' and LastNameForDisplay like 'Hanya'), (select Id from Book where TitleForDisplay like 'Małe życie' and 
ISBN like '9788328026483'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Jojo' and LastNameForDisplay like 'Moyes') and 
BookId = (select Id from Book where TitleForDisplay like 'Zanim się pojawiłeś' and ISBN like '9788380315884'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Jojo' and LastNameForDisplay like 'Moyes'), (select Id from Book where TitleForDisplay like 'Zanim się pojawiłeś' and 
ISBN like '9788380315884'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Magdalena' and LastNameForDisplay like 'Kordel') and 
BookId = (select Id from Book where TitleForDisplay like 'Nadzieje i marzenia' and ISBN like '9788324041343'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Magdalena' and LastNameForDisplay like 'Kordel'), (select Id from Book where TitleForDisplay like 'Nadzieje i marzenia' and 
ISBN like '9788324041343'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Charlotte' and LastNameForDisplay like 'Link') and 
BookId = (select Id from Book where TitleForDisplay like 'Złudzenie' and ISBN like '9788379996551'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Charlotte' and LastNameForDisplay like 'Link'), (select Id from Book where TitleForDisplay like 'Złudzenie' and 
ISBN like '9788379996551'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Katarzyna' and LastNameForDisplay like 'Puzyńska') and 
BookId = (select Id from Book where TitleForDisplay like 'Łaskun' and ISBN like '9788380693579'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Katarzyna' and LastNameForDisplay like 'Puzyńska'), (select Id from Book where TitleForDisplay like 'Łaskun' and 
ISBN like '9788380693579'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Sandra' and LastNameForDisplay like 'Brown') and 
BookId = (select Id from Book where TitleForDisplay like 'W objęciach nocy' and ISBN like '9788379432264'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Sandra' and LastNameForDisplay like 'Brown'), (select Id from Book where TitleForDisplay like 'W objęciach nocy' and 
ISBN like '9788379432264'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Katarzyna' and LastNameForDisplay like 'Michalak') and 
BookId = (select Id from Book where TitleForDisplay like 'Zemsta' and ISBN like '9788324036189'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Katarzyna' and LastNameForDisplay like 'Michalak'), (select Id from Book where TitleForDisplay like 'Zemsta' and 
ISBN like '9788324036189'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Agnieszka' and LastNameForDisplay like 'Lingas-Łoniewska') and 
BookId = (select Id from Book where TitleForDisplay like 'Piętno Midasa' and ISBN like '9788380831377'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Agnieszka' and LastNameForDisplay like 'Lingas-Łoniewska'), (select Id from Book where TitleForDisplay like 'Piętno Midasa' and 
ISBN like '9788380831377'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Jan' and LastNameForDisplay like 'Kaczkowski') and 
BookId = (select Id from Book where TitleForDisplay like 'Grunt pod nogami' and ISBN like '9788327710376'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Jan' and LastNameForDisplay like 'Kaczkowski'), (select Id from Book where TitleForDisplay like 'Grunt pod nogami' and 
ISBN like '9788327710376'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Hendrik' and LastNameForDisplay like 'Groen') and 
BookId = (select Id from Book where TitleForDisplay like 'Małe eksperymenty ze szczęściem' and ISBN like '9788379857432'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Hendrik' and LastNameForDisplay like 'Groen'), (select Id from Book where TitleForDisplay like 'Małe eksperymenty ze szczęściem' and 
ISBN like '9788379857432'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Morgane' and LastNameForDisplay like 'Séliman') and 
BookId = (select Id from Book where TitleForDisplay like 'Okradziona z życia' and ISBN like '9788324158249'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Morgane' and LastNameForDisplay like 'Séliman'), (select Id from Book where TitleForDisplay like 'Okradziona z życia' and 
ISBN like '9788324158249'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Julia' and LastNameForDisplay like 'Raczko') and 
BookId = (select Id from Book where TitleForDisplay like 'Gdzie jest Julia?' and ISBN like '9788376426730'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Julia' and LastNameForDisplay like 'Raczko'), (select Id from Book where TitleForDisplay like 'Gdzie jest Julia?' and 
ISBN like '9788376426730'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Zdzisław' and LastNameForDisplay like 'Beksiński') and 
BookId = (select Id from Book where TitleForDisplay like 'Beksiński - dzień po dniu kończącego się życia' and ISBN like '9788361443117'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Zdzisław' and LastNameForDisplay like 'Beksiński'), 
(select Id from Book where TitleForDisplay like 'Beksiński - dzień po dniu kończącego się życia' and 
ISBN like '9788361443117'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Jarosław Mikołaj' and LastNameForDisplay like 'Skoczeń') and 
BookId = (select Id from Book where TitleForDisplay like 'Beksiński - dzień po dniu kończącego się życia' and ISBN like '9788361443117'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Jarosław Mikołaj' and LastNameForDisplay like 'Skoczeń'), 
(select Id from Book where TitleForDisplay like 'Beksiński - dzień po dniu kończącego się życia' and 
ISBN like '9788361443117'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Tomas' and LastNameForDisplay like 'Prower') and 
BookId = (select Id from Book where TitleForDisplay like 'La Santa Muerte' and ISBN like '9788365442284'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Tomas' and LastNameForDisplay like 'Prower'), 
(select Id from Book where TitleForDisplay like 'La Santa Muerte' and 
ISBN like '9788365442284'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Andrea' and LastNameForDisplay like 'Hutton') and 
BookId = (select Id from Book where TitleForDisplay like 'Boska bez włoska' and ISBN like '9788365506382'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Andrea' and LastNameForDisplay like 'Hutton'), 
(select Id from Book where TitleForDisplay like 'Boska bez włoska' and 
ISBN like '9788365506382'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Jerzy' and LastNameForDisplay like 'Zięba') and 
BookId = (select Id from Book where TitleForDisplay like 'Ukryte terapie' and ISBN like '9788394078317'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Jerzy' and LastNameForDisplay like 'Zięba'), 
(select Id from Book where TitleForDisplay like 'Ukryte terapie' and 
ISBN like '9788394078317'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Elżbieta' and LastNameForDisplay like 'Cherezińska') and 
BookId = (select Id from Book where TitleForDisplay like 'Królowa' and ISBN like '9788365521385'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Elżbieta' and LastNameForDisplay like 'Cherezińska'), 
(select Id from Book where TitleForDisplay like 'Królowa' and 
ISBN like '9788365521385'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'Autor Laurelin' and LastNameForDisplay like 'Paige') and 
BookId = (select Id from Book where TitleForDisplay like 'Uwikłani Tom 1. Pokusa' and ISBN like '9788365170163'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'Autor Laurelin' and LastNameForDisplay like 'Paige'), 
(select Id from Book where TitleForDisplay like 'Uwikłani Tom 1. Pokusa' and 
ISBN like '9788365170163'));

if not exists(select * from AuthorBook where AuthorId = (select Id from Author where FirstName like 'George R.R.' and LastNameForDisplay like 'Martin') and 
BookId = (select Id from Book where TitleForDisplay like 'Rycerz Siedmiu Królestw' and ISBN like '9788377854167'))
insert into AuthorBook(AuthorId, BookId)
values((select Id from Author where FirstName like 'George R.R.' and LastNameForDisplay like 'Martin'), 
(select Id from Book where TitleForDisplay like 'Rycerz Siedmiu Królestw' and 
ISBN like '9788377854167'));