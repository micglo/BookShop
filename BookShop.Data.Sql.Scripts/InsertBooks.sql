--Książki/Literatura piękna/Powieść społeczno-obyczajowa
if not exists(select * from Book where TitleForDisplay like 'Przeznaczeni' and ISBN like '9788308061633')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, BookSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Przeznaczeni', 'Przeznaczeni', (select Id from Publishing where NameForDisplay like 'Literackie'), '2016-05-19', '9788308061633', 556, '12.3x19.7cm', 
'http://www.ravelo.pl/pub/mm/multimedia/image/jpeg/100431816.jpg', 1, 0, 1, 'Oto jest! Nowa powieść Katarzyny Grocholi.

Los? Przypadek? Co kieruje naszym życiem?

Życiowo prawdziwa, nasączona nadzieją i dojrzałym optymizmem, ta książka to Twoje przeznaczenie

O tej książce można opowiadać na wiele sposobów. Na przykład tak: Przeznaczeni to historia pięciu osób. Pozornie nie mają ze sobą nic wspólnego, ale już wkrótce zbiegi okoliczności i przypadkowe na pierwszy rzut oka zdarzenia sprawią, że ich drogi nierozerwalnie się połączą.

Olin jest rozchwytywaną autorką kryminałów. Ma wszystko: pieniądze, sławę, sukces, jest nawet zakochana. Problem w tym, że nie do końca szczęśliwie. Od wielu lat ma romans z żonatym facetem. Historia jakich wiele: ona kocha jego, on kocha tylko ją, no ale żona, dzieci…

Gabrysia pracuje w kasynie. Każdego dnia obserwuje ludzi, którzy wygrali albo przegrali. Sama jest nieufna i żyje na uboczu. Aż do momentu, gdy – przypadkiem – spotyka Mateusza. Mateusz jest zdolnym grafikiem i beztroskim singlem. Ma pieniądze i kobiety. Pieniądze co prawda pożyczył swojemu przyjacielowi Kubie, ale kobiet w jego życiu nie brakuje – pojawiają się i znikają. Wszystko się zmienia, gdy spotyka Gabrysię. Ta kobieta to dla niego tajemnica, którą musi rozwikłać.

Kuba jest alkoholikiem. Niepijącym. W poszukiwaniu lepszego jutra wyrusza do Stanów Zjednoczonych. Pożyczone od Mateusza pieniądze błyskawicznie trafiają w ręce Jurka (zwanego Jerrym), polskiego emigranta, który w Ameryce dorobił się synów i kolejnych żon, a także paru szemranych interesów, na których nieustannie ma nadzieję się dorobić. Historie wszystkich bohaterów zbiegają się w kulminacyjnym punkcie. Jedni otrzymają szansę od losu, inni tę szansę bezpowrotnie stracą…

Przeznaczeni to absolutny majstersztyk, na który warto było czekać cztery długie lata.

Katarzyna Grochola, najpopularniejsza polska pisarka, postawiła wszystko na jedną kartę i napisała powieść, jakiej jeszcze nie było. Przemyślaną i misternie skonstruowaną. Mądrą, czasem zabawną, a momentami bardzo poważną. O poplątanym życiu, wzlotach i upadkach. O zderzeniach z rzeczywistością, ale nasączoną dojrzałym optymizmem. To powieść, w której gra toczy się o naprawdę dużą stawkę.', 
28.75, 1000);

if not exists(select * from Book where TitleForDisplay like 'Tajemniczy brat' and ISBN like '9788380694057')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, BookSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Tajemniczy brat', 'Tajemniczy-brat', (select Id from Publishing where NameForDisplay like 'Prószyński Media'), '2016-07-05', '9788380694057', 384, '12.5x18.7cm', 
'http://www.ravelo.pl/pub/mm/multimedia/image/jpeg/100454574.jpg', 1, 0, 1, 
'Najbardziej zaskakująca opowieść o Dollangangerach od czasów „Kwiatów na poddaszu”.

Ostatni tom sagi Dollangangerów ponownie przenosi nas w przeszłość. Z pozoru akcja nie ma związku z poprzednimi, w których młoda Kristin poznaje pamiętnik Christophera Dollangangera - najstarszego z czwórki dzieci, uwięzionych niegdyś na poddaszu rezydencji - znaleziony w ruinach Foxworth Hall.

Młody chłopiec, podrzucony do szpitala, zostaje adoptowany przez bogatą rodzinę. Cierpi na amnezję – i jeszcze nie wie, że lepiej by było, aby nigdy nie przypomniał sobie przeszłości…

Starszy człowiek traci wnuka w tragicznym wypadku drogowym. To kolejne nieszczęście w jego życiu, gdyż wcześniej stracił już córkę i zięcia, a potem żonę. W tym samym czasie do szpitala trafia tajemniczy chłopiec, schorowany i nieszczęśliwy. Zrozpaczony dziadek postanawia zająć się nim i wziąć go pod swój dach, aby zastąpił mu utracone dziecko. Napotyka jednak na opór wnuczki. Nastoletnia Clara Sue traktuje chłopca jak intruza i najchętniej pozbyłaby się „tajemniczego brata”. Usiłuje dojść, kim jest, aby szybciej zwrócić go prawdziwej rodzinie. Mroczna przeszłość wkrótce odsłoni swoją ostatnią tajemnicę.

Fenomen popularności V.C. Andrews trwa nieustannie od czasu wydania „Kwiatów na poddaszu”. Książki autorki, tworzące kilkanaście bestsellerowych serii, osiągnęły łączny nakład ponad 106 milionów egzemplarzy i zostały przetłumaczone na dwadzieścia dwa języki.

„Tajemniczy brat” to trzecia część trylogii opowiadającej o dalszych losach rodziny Dollangangerów (znanych czytelnikom m.in. z „Kwiatów na poddaszu”). Kolejne powieści autorki ukażą się wkrótce nakładem Prószyński i S-ka.', 
25.30, 1000);

if not exists(select * from Book where TitleForDisplay like 'Małe życie' and ISBN like '9788328026483')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, BookSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Małe życie', 'Male-zycie', (select Id from Publishing where NameForDisplay like 'W.A.B.'), '2016-05-18', '9788328026483', 800, '15.0x25.5cm', 
'http://www.ravelo.pl/pub/mm/multimedia/image/jpeg/100420136.jpg', 1, 0, 1, 
'Światowa sensacja literacka! Najgłośniejsza amerykańska powieść ubiegłego roku, nominowana do Nagrody Bookera i National Book Award; laureatka prestiżowej Kirkus Prize.

Powieść, która wzbudziła falę zachwytu, a zarazem gorącą dyskusję wśród krytyków i czytelników. Poruszający obraz dojrzewania, sukcesu, traumy i przyjaźni.

Wydana w 2015 roku powieść Małe życie w Ameryce i w Anglii odniosła ogromny sukces wśród krytyków i czytelników - trafiła do finału Nagrody Bookera i National Book Award, otrzymała prestiżową Kirkus Prize, znalazła się na czele rankingów najlepszych powieści roku sporządzonych przez najważniejsze tytuły prasowe, rozgłośnie radiowe i portale internetowe.

Zachwycająca powieść o przyjaźni poddanej ogromnej próbie.

Oto historia życia czterech przyjaciół – o ich niełatwym dojrzewaniu, ogromnych sukcesach, bolesnych wyborach i tyranii pamięci, od której nie sposób czasem się uwolnić… To również opowieść o jednym z najbardziej fascynujących miast świata – Nowym Jorku – który jest piątym, równorzędnym bohaterem tej olśniewającej książki.

Pochodząca z Hawajów amerykańska pisarka opisuje kilkadziesiąt lat z życia czterech przyjaciół. Bohaterów powieści poznajemy w chwili, gdy kończą studia i przenoszą się do Nowego Jorku. Przetrwanie, nie mówiąc już o sukcesie, w jednym z najwspanialszych miast świata nie jest łatwe, lecz szczęście wydaje się im sprzyjać. Pełen temperamentu JB jest malarzem i z czasem zaczyna brylować w kręgach nowojorskiej bohemy. Malcolm zostaje uznanym architektem, a Willem robi błyskotliwą karierę aktorską. Najbardziej tajemniczy z nich, Jude, przejawia wybitny talent matematyczny, a jako prawnik również odnosi sukces za sukcesem. W przeciwieństwie do przyjaciół nigdy jednak nie wspomina o swojej przeszłości ani o rodzinie, choć poważne problemy zdrowotne i emocjonalne wskazują na to, że w jego życiu wydarzyło się coś, o czym nie potrafi zapomnieć.

Willem, Malcolm i JB stopniowo odkrywać będą straszną prawdę, która kładzie się cieniem na całym życiu przyjaciela. Nieuchronnie nadchodzi dla nich czas trudnej próby empatii i dojrzałości. Co będą gotowi poświęcić, by ratować Jude''a, coraz bardziej pogrążającego się w mroku? Oto poruszająca do głębi opowieść o życiu w wielkim mieście, które daje szansę na zapomnienie o przeszłości, oraz o życiu w bólu, który nie pozwala zapomnieć. To proza, która w całym swoim pięknie opisuje doświadczenie zła, granice ludzkiej wytrzymałości i tyranię pamięci.', 
44.50, 1000);

if not exists(select * from Book where TitleForDisplay like 'Zanim się pojawiłeś' and ISBN like '9788380315884')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, BookSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Zanim się pojawiłeś', 'Zanim-sie-pojawiles', (select Id from Publishing where NameForDisplay like 'Świat Książki'), '2016-04-28', '9788380315884', 384, '13.5x21.5cm', 
'http://www.ravelo.pl/pub/mm/multimedia/image/jpeg/100433143.jpg', 0, 0, 0, 
'Dwudziestosześcioletnia Lou spotyka na swej drodze Willa. Ona właśnie straciła pracę i rozstała się ze swoim chłopakiem, a on po wypadku motocyklowym nie ma chęci do życia i chce je sobie odebrać. Will nie wie jeszcze, że Lou wtargnie w jego życie niczym kolorowy ptak.

Czy wielka miłość, nawet bolesna, naprawdę może przezwyciężyć frustrację, zniechęcenie i natarczywe myśli o samobójstwie? Doskonale rozegrana psychologicznie, sugestywna powieść o sile uczuć i magicznym wpływie człowieka na człowieka.', 
27.20, 1000);

if not exists(select * from Book where TitleForDisplay like 'Nadzieje i marzenia' and ISBN like '9788324041343')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Nadzieje i marzenia', 'Nadzieje-i-marzenia', (select Id from Publishing where NameForDisplay like 'Znak'), '2016-06-01', '9788324041343', 436, 
'http://www.ravelo.pl/pub/mm/multimedia/image/jpeg/100429696.jpg', 0, 0, 0, 
'Zajrzyj do Malowniczego. Tu czas płynie wolniej, a marzenia stają się rzeczywistością Magda otrzymuje tajemniczy list z francuskiej kancelarii. Niebawem Malownicze zatrzęsie się od plotek o spadku. Wszyscy będą chcieli wiedzieć, czy z dnia na dzień Magda stanie się bajecznie bogata. Ona jednak ma inne kłopoty. Musi wreszcie odpowiedzieć sobie na najważniejsze pytania: czy chce dalej być z Michałem i jak ma wyglądać ich wspólne życie. Odpowiedź nie jest taka prosta.

Sto pięćdziesiąt lat wcześniej, gdzieś w u podnóża Gór Świętokrzyskich, Sabina ryzykując życie angażuje się w spisek przeciwko zaborcom. Adam kocha ją do szaleństwa i za wszelką cenę uchronić przed niebezpieczeństwem. Przewrotny los jednak chce inaczej. Co łączy tak odległą historię Sabiny z Magdą? Czy sekret z przeszłości pomoże jej odnaleźć swoje przeznaczenie i spełnić marzenia?

Podobnie jak moi bohaterowie, ja też mocno wierzę w to, że czasowi trzeba dać czas, by marzenia i nadzieje mogły się ziścić. ', 
26.59, 1000);


--Książki/Literatura piękna/Sensacja, kryminał, thriller
if not exists(select * from Book where TitleForDisplay like 'Złudzenie' and ISBN like '9788379996551')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, BookSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Złudzenie', 'Zludzenie', (select Id from Publishing where NameForDisplay like 'Sonia Draga'), '2016-05-06', '9788379996551', 528, '14.3x20.5cm', 
'http://www.ravelo.pl/pub/mm/multimedia/image/jpeg/100427531.jpg', 1, 0, 1, 
'Wielowarstwowa, wyrafinowana i trzymająca w napięciu do ostatniej strony nowa powieść kryminalna z wątkiem psychologicznym autorki bestsellerów Charlotte Link.

Peter Simon, szanowany biznesmen, człowiek sukcesu, kochający mąż i ojciec znika bez śladu podczas podróży do Prowansji. Jego żona, Laura, zaczyna go rozpaczliwie szukać. We Francji odkrywa kolejne rewelacje, zaprzeczające obrazowi męża, jaki miała do tej pory. Kobieta nie tylko musi się pogodzić ze świadomością, że Peter wcale nie był takim człowiekiem, za jakiego go uważano...

Ale także zmierzyć się z tym, że odkrycie prawdy wiąże się ze śmiertelnym niebezpieczeństwem.', 
27.40, 1000);

if not exists(select * from Book where TitleForDisplay like 'Łaskun' and ISBN like '9788380693579')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, BookSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Łaskun', 'Laskun', (select Id from Publishing where NameForDisplay like 'Prószyński Media'), '2016-06-07', '9788380693579', 832, '12.5x19.5cm', 
'http://www.ravelo.pl/pub/mm/multimedia/image/jpeg/100433369.jpg', 1, 0, 0, 
'Szósty tom sagi kryminalnej o policjantach z Lipowa.

Opowieści o Lipowie łączą w sobie elementy klasycznego kryminału i powieści obyczajowej z rozbudowanym wątkiem psychologicznym. Porównywane są do książek Agathy Christie i powieści szwedzkiej królowej gatunku, Camilli Läckberg. Prawa do publikacji serii sprzedane zostały do ponad dwudziestu krajów.

W domu pewnego bezrobotnego sędziego policja odkrywa makabryczną inscenizację. Sprawca stworzył postać składającą się z rozczłonkowanych zwłok prawnika i nieznanej kobiety. Wkrótce okazuje się, że na miejscu zbrodni znajduje się dowód obciążający aspiranta Daniela Podgórskiego. Odkrycie tożsamości drugiej ofiary tylko pogarsza sytuację policjanta. Czyżby to Daniel był mordercą? A może to ktoś z komendy chce go wrobić w podwójne zabójstwo? Ale skoro Podgórski jest niewinny, to dlaczego ucieka?', 
27.42, 1000);

if not exists(select * from Book where TitleForDisplay like 'W objęciach nocy' and ISBN like '9788379432264')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, BookSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('W objęciach nocy', 'W-objeciach-nocy', (select Id from Publishing where NameForDisplay like 'Świat Książki'), '2016-06-18', '9788379432264', 368, '12.5x20.0cm', 
'http://www.ravelo.pl/pub/mm/img/220/100463595.jpg', 1, 0, 0, 
'Lydia Bryant jest w ciąży. Jej dziecko jest wynikiem gwałtu, a młoda dziewczyna musi uciec przed swoim prześladowcą. Gdy w drodze zaskakuje ją poród, jest bezradna. Nie umie i nie chce pomóc dziecku przyjść na świat. Sama też woli umrzeć. Lydię znajdują dwaj chłopcy, którzy zabierają ją do swojego domu. Ich matka z zaangażowaniem opiekuje się dziewczyną. W tym samym czasie piękna i elegancka Victoria, ukochana żona Rossa Colemana, rodzi dziecko, ale umiera przy porodzie. Ross musi sam opiekować się z noworodkiem. Mamką małego Lee zostaje Lydia. Dziewczyna cały czas ukrywa prawdę o swojej przeszłości. Przeszłości, która ją odnajduje... Ross jest zafascynowany Lydią, ale ma dylemat moralny – jego żona zmarła tak niedawno. Poza tym on również skrywa mroczną przeszłość. Czy tych dwoje zaufa sobie na tyle, żeby stworzyć rodzinę?', 
24.35, 1000);

if not exists(select * from Book where TitleForDisplay like 'Zemsta' and ISBN like '9788324036189')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Zemsta', 'Zemsta', (select Id from Publishing where NameForDisplay like 'Znak'), '2016-04-13', '9788324036189', 304, 
'http://www.ravelo.pl/pub/mm/multimedia/image/jpeg/100406737.jpg', 0, 0, 1, 
'Są błędy, których nie sposób naprawić. 
Są winy, których nie można wybaczyć. I są ludzie, którzy nie spoczną, dopóki nie nasycą się zemstą…

Ulicami miasta biegnie ranna dziewczyna. Udało jej się uciec. Na jak długo? Jej tropem podąża pościg. Ale biegnący w ślad za nią zabójcy wiedzą, że oni też muszą oglądać się za siebie. Bo jest ktoś, kto gotów jest nawet wstać z martwych, żeby ją uratować.

Rozpoczyna się śmiertelnie niebezpieczna gra z czasem, w której stawką jest więcej niż jedno życie. Czyja krew zostanie przelana, a kto poczuje słodki smak zemsty? Kto tak naprawdę jest tu myśliwym, a kto ofiarą?

Zemsta to wybuchowa mieszanka tajemnicy, akcji i pożądania. Ale także opowieść o potędze miłości, zdolnej odkupić błędy z przeszłości… lub strącić w najczarniejszą otchłań.', 
26.59, 1000);

if not exists(select * from Book where TitleForDisplay like 'Piętno Midasa' and ISBN like '9788380831377')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Piętno Midasa', 'Pietno-Midasa', (select Id from Publishing where NameForDisplay like 'Novae Res'), '2016-06-10', '9788380831377', 360, 
'http://www.ravelo.pl/pub/mm/multimedia/image/jpeg/100435278.jpg', 0, 0, 0, 
'Brudne podwórka wrocławskiego Trójkąta Bermudzkiego... Chłopak, który urodził się w niewłaściwej rodzinie i człowiek, który dał mu szansę. Tylko… na co?

Jakub Rojalski, zabójczo przystojny pasjonat fotografii, podczas przyjęcia weselnego poznaje inspektor Karolinę Linde, szefową wydziału śledczego wrocławskiej policji. Kobieta jest sfrustrowana i przemęczona, ponieważ dochodzenie w sprawie płatnego zabójcy utknęło w martwym punkcie, tymczasem Midas uśmierca kolejne ofiary. Wbrew woli obojga jednorazowy incydent powoli zamienia się w romans, a Jakub uświadamia sobie, że nie potrafi dłużej żyć, tłumiąc w sobie wszelkie emocje. Jednocześnie w jego życiu pojawia się Anka, magister farmacji i maltretowana żona gangstera, marząca o zemście na mężu. Któregoś dnia okazuje się, że Jakub potrafi jej pomóc…

Jestem Midas. Do widzenia.

Karma to suka.', 
26.59, 1000);


----Książki/Literatura faktu/Wspomnienia, dzienniki, listy
if not exists(select * from Book where TitleForDisplay like 'Grunt pod nogami' and ISBN like '9788327710376')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Grunt pod nogami', 'Grunt-pod-nogami', (select Id from Publishing where NameForDisplay like 'WAM'), '2016-05-24', '9788327710376', 250, 
'http://www.ravelo.pl/pub/mm/multimedia/image/jpeg/100401817.jpg', 1, 0, 0, 
'Credo księdza Jana Kaczkowskiego

Miliony Polaków pokochały go za wyrozumiałość dla słabości drugiego człowieka, wierność sobie, błyskotliwe poczucie humoru i determinację w walce ze śmiertelną chorobą.

Jak wygląda relacja ks. Jana z Bogiem? Jakie wartości są mu najbliższe? Które fragmenty Ewangelii są dla niego najważniejsze? O czym chce zdążyć opowiedzieć tłumom, które przychodzą na jego msze, a jakie słowa zachowuje dla pacjentów swojego hospicjum?

Grunt to twardo stąpać po ziemi i nie przestawać patrzeć w niebo. Zamiast ciągle na coś czekać - zacznij żyć, właśnie dziś. Jest o wiele później niż Ci się wydaje.

Ksiądz Jan Kaczkowski to nie tylko Życie na pełnej petardzie, ale też setki kazań wygłoszonych w całej Polsce i poza jej granicami. Książka ta to wybór tych, które jego zdaniem najlepiej pokazują najbliższe mu tematy: wierność sumieniu, odwaga, wewnętrzna uczciwość, pokonywanie własnych słabości, budowanie bliskości i autentycznych relacji. Niezależnie od tego, czy były wygłoszone dla tłumów, które przychodziły na jego msze, czy dla pacjentów hospicjum w Pucku i ich rodzin, widzimy w nich księdza Jana, który dzieli się tym, co dla niego najważniejsze.

Książka zawiera też rekolekcje z księdzem Janem "Herod, Piłat, setnik i inni" oraz przewodnik po dobrej spowiedzi.', 
23.69, 1000);

if not exists(select * from Book where TitleForDisplay like 'Małe eksperymenty ze szczęściem' and ISBN like '9788379857432')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Małe eksperymenty ze szczęściem', 'Male-eksperymenty-ze-szczesciem', (select Id from Publishing where NameForDisplay like 'Albatros'), '2016-05-12', '9788379857432', 400, 
'http://www.ravelo.pl/pub/mm/multimedia/image/jpeg/100415476.jpg', 1, 0, 1, 
'PRAWA DO PUBLIKACJI KSIĄŻKI KUPILI WYDAWCY Z 25 KRAJÓW.

KSIĄŻKA PRZEZ 30 TYGODNI UTRZYMYWAŁA SIĘ NA HOLENDERSKICH LISTACH BESTSELLERÓW KSIĄŻKOWYCH

HOLENDERSKA TELEWIZJA KUPIŁA PRAWO DO SERIALOWEJ ADAPTACJI KSIĄŻKI – NA JEJ PODSTAWIE MA POWSTAĆ SITCOM W STYLU BRYTYJSKIEGO „THE OFFICE"

To międzynarodowy fenomen literacki, którego autor wciąż pozostaje nieznany. Książka przez 30 tygodni utrzymywała się na holenderskich listach bestsellerów, a prawa do publikacji kupili wydawcy z ponad trzydziestu krajów.

Hendrik Groen jest zgryźliwym staruszkiem, którego specyficzne poczucie humoru i introwertyczna natura budzą skojarzenia z Adrianem Molem i jego gorzko-słodkim pamiętnikiem czasów dojrzewania. Tym razem jednak mowa o starości i związanych z nią problemach, które nie często poznajemy z pierwszej ręki. W krótkich, szczerych i bezpretensjonalnych wpisach do dziennika śledzimy pełen wzlotów i upadków rok z życia Hendrika Groena.

Hendrik Groen być może jest stary, ale z pewnością jeszcze nie martwy. Choć ciało odmawia mu posłuszeństwa, jeszcze się nie poddał. To prawda, że jego codzienne spacery są coraz krótsze, ponieważ nogi odmawiają mu posłuszeństwa, to prawda, że musi regularnie odwiedzać swojego lekarza rodzinnego. Z technicznego punku widzenia jest zgrzybiałym dziadkiem, nie zamierza jednak siedzieć bezczynnie, czekając na śmierć. Ale czy to jest powód, żeby życie musiało się od razu składać tylko z popijania kawy przy doniczkach z geranium i czekania na koniec?

W krótkich, szczerych i bezpretensjonalnych wpisach do dziennika, śledzimy pełen wzlotów i upadków rok z życia Hendrika Groena, przebywającego w domu spokojnej starości w północnej części Amsterdamu. Hendrik powołuje do życia anarchistyczny KLUB JESZCZE ŻYWYCH STARUSZKÓW, a gdy na horyzoncie pojawia się Eefje, idealna druga połówka, pastuje buty, szczotkuje zęby, przygładza resztki czupryny i rusza do boju, nie bacząc na śmieszne i straszne konsekwencje. Dni szybko mijają i z każdym kolejnym nabieramy pewności, że nie będzie łatwo rozstać się z tym pełnym uroku staruszkiem.

HENDRIK GROEN ROZPOCZĄŁ PISANIE DZIENNIKA NA INTERNETOWEJ STRONIE „TORPEDO MAGAZINE”, POTEM PRZYSZŁA PROPOZYCJA Z WYDAWNICTWA MEULENHOFF, ABY ZROBIĆ Z TEGO KSIĄŻKĘ. O SWOJEJ POWIEŚCI AUTOR MÓWI TAK:

Ani jedno zdanie nie jest kłamstwem, chociaż nie każde słowo jest prawdziwe.', 
31.92, 1000);

if not exists(select * from Book where TitleForDisplay like 'Okradziona z życia' and ISBN like '9788324158249')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, BookSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Okradziona z życia', 'Okradziona-z-zycia', (select Id from Publishing where NameForDisplay like 'Amber'), '2016-05-26', '9788324158249', 224, '20.5x13.0cm',
'http://www.ravelo.pl/pub/mm/multimedia/image/jpeg/100431539.jpg', 1, 0, 0, 
'Przez cztery lata miał absolutną władzę nad jej ciałem i psychiką. Przetrwała, bo strach o własne życie był jednak silniejszy. Morgane i Yassine są Francuzami arabskiego pochodzenia. Krótko byli szczęśliwi. Kiedy przyszła niechciana ciąża, zaczął się dramat. Pobił ją po raz pierwszy… Potem coraz częstsze bicie stało się potwornym rytuałem: Mija godzina, od kiedy zaczęło się odliczanie. Spieszę się, żeby zdążyć wszystko wyprasować. Potem będę za bardzo obolała. Pół godziny! Jeszcze boli mnie głowa po wczorajszym biciu. Dziesięć minut! Biorę synka na ręce i idę położyć go spać. Nie chcę, żeby moje dziecko czuło, że się boję. Yassine włączył muzykę, żeby zagłuszyć hałas. – Chodź tutaj! – Trzy kroki. Ręce wzdłuż ciała! Mam wrażenie, że moje serce za chwilę eksploduje. Jedno uderzenie w twarz, drugie, potem ciosy pięścią. Kiedy upadam, zaczyna mnie kopać. – Błagam cię, przestań! – Zwinięta w kłębek próbuję osłaniać się, jak potrafię… Przez cztery lata miał absolutną władzę nad jej ciałem i psychiką. Przetrwała, bo strach o własne życie był jednak silniejszy. Odważyła się zadzwonić na policję, uciekła, ukrywała się. Teraz próbuje ułożyć sobie życie od nowa… MORGANE SÉLIMAN ma 32 lata i mieszka w Normandii. Jej historia stała się głośna, kiedy wzięła udział na programie telewizyjnym znanego dziennikarza Oliviera Delacroix, którego tematem były zagrożenia, w jakich żyją kobiety. Według szacunków Światowej Organizacji Zdrowia (WHO) z 2013 roku blisko jedna trzecia (30%) kobiet pozostających w związku było ofiarą fizycznej i/lub seksualnej przemocy ze strony partnera. 38% zabójstw kobiet zostało popełnione przez ich partnera. 20% kobiet będzie ofiarą gwałtu lub próby gwałtu.', 
23.84, 1000);

if not exists(select * from Book where TitleForDisplay like 'Gdzie jest Julia?' and ISBN like '9788376426730')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, BookSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Gdzie jest Julia?', 'Gdzie-jest-Julia', (select Id from Publishing where NameForDisplay like 'Pascal'), '2016-04-16', '9788376426730', 336, '14.4x20.8cm',
'http://www.ravelo.pl/pub/mm/multimedia/image/jpeg/100415791.jpg', 0, 0, 1, 
'Bo życie trzeba przeżyć a nie tylko mieć! Gdzie jest Julia? to opowieść o sześciomiesięcznej podróży przez Tajlandię, Malezję, Indonezję, Australię, Nową Zelandię, Polinezję Francuską, Chile, Peru, Kubę i Meksyk. Książkowy debiut znanej blogerki jest historią samotnej wyprawy, w której najważniejsi okazują się... ludzie - ci pozostawieni w kraju i ci poznani w drodze. To opis rozmów, na które wcześniej nie starczało czasu, błędy niedoświadczonego podróżnika, momenty zwątpienia i szaleńczej radości. Jest także miłość, ta do świata, do Australii i do mężczyzny. Wyprawa w nieznane, która kończy się... a kto powiedział że to koniec? No i gdzie jest Julia?!', 
27.92, 1000);

if not exists(select * from Book where TitleForDisplay like 'Beksiński - dzień po dniu kończącego się życia' and ISBN like '9788361443117')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, BookSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Beksiński - dzień po dniu kończącego się życia', 'Beksinski-dzien-po-dniu-konczącego-sie-zycia', (select Id from Publishing where NameForDisplay like 'MD'), 
'2016-03-09', '9788361443117', 448, '14.0x22.0cm',
'http://www.ravelo.pl/pub/mm/multimedia/image/jpeg/100410698.jpg', 0, 0, 0, 
'W książce opublikowane zostały obszerne fragmenty dzienników Zdzisława Beksińskiego z lat 1993-2005, w których artysta bardzo szczerze, z charakterystycznym dla siebie poczuciem humoru i ironią opisuje otaczającą go rzeczywistość – ludzi, którzy przy nim byli i sprawy, które go zajmowały.

Nie ucieka także od spraw trudnych i bolesnych - pisze o śmierci, przemijaniu, samotności, chorobie. Niejako uzupełnieniem dzienników jest rozmowa z wieloletnim przyjacielem artysty, Wiesławem Banachem, który ze swojej perspektywy, ale z ogromną dozą zrozumienia i empatii, opowiada o życiu, twórczości, rodzinie, rozterkach, światopoglądzie malarza. To właśnie jemu Zdzisław Beksiński powierzył cały dorobek swojego życia – zarówno artystycznego jak i prywatnego. Dorobek, dzięki któremu chciał trwać jak najdłużej, długo po swojej śmierci. Wiesław Banach był dla niego gwarantem, że świat o nim nie zapomni...', 
35.92, 1000);


--Książki/Książki naukowe i popularnonaukowe
if not exists(select * from Book where TitleForDisplay like 'La Santa Muerte' and ISBN like '9788365442284')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, BookSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('La Santa Muerte', 'La-Santa-Muerte', (select Id from Publishing where NameForDisplay like 'Illuminatio'), 
'2016-01-01', '9788365442284', 328, '14.5x20.5x1.5 cm',
'http://www.taniaksiazka.pl/images/popups/05D/9788365442284.jpg', 1, 0, 0, 
'Tomás Prower, autor książki La Santa Muerte, odsłania sekrety tajemniczego kultu wywodzącego się z Ameryki Południowej. Prezentuje historię i kulturę La Santa Muerte – kultu patronki przegranych spraw, społeczności LGBT, osób uzależnionych i wszystkich zepchniętych na margines społeczeństwa.', 
29.93, 1000);

if not exists(select * from Book where TitleForDisplay like 'Boska bez włoska' and ISBN like '9788365506382')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, BookSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Boska bez włoska', 'Boska-bez-wloska', (select Id from Publishing where NameForDisplay like 'Kobiece'), 
'2016-01-01', '9788365506382', 200, '13.5x20.5x2 cm',
'http://www.taniaksiazka.pl/images/popups/807/9788365506382.jpg', 1, 0, 0, 
'KOMPLEKSOWA POMOC W WALCE Z RAKIEM PIERSI

Rak piersi to najczęściej występujący nowotwór złośliwy wśród kobiet. W Polsce rozpoznaje się go zwykle o kobiet w wieku 50-70 lat, jednak ostatnie badania wskazują na to, że ta choroba dotyka coraz częściej dużo młodsze kobiety. W ciągu 30 lat zachorowalność na raka piersi wzrosła niemal dwukrotnie, również w Polsce.

Mimo to na polskim rynku wydawniczym jest bardzo mało publikacji na ten temat. Tę lukę w świetny sposób uzupełnia Andrea Hutton, proponując ultrakobiecy, okraszony subtelnym humorem poradnik pełen praktycznych porad i wskazówek dotyczących tego, jak przejść ten trudny okres w życiu.

PAMIĘTAJ, ŻE NIE JESTEŚ SAMA – ANDREA HUTTON POMOŻE CI PRZETRWAĆ TEN TRUDNY CZAS', 
27.57, 1000);

if not exists(select * from Book where TitleForDisplay like 'Ukryte terapie' and ISBN like '9788394078317')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, BookSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Ukryte terapie', 'Ukryte-terapie', (select Id from Publishing where NameForDisplay like 'Jerzy Zięba'), 
'2016-01-01', '9788394078317', 335, '15.0x21.5x2.5 cm',
'http://www.taniaksiazka.pl/images/popups/CF7/EGIDA01.jpg', 0, 0, 1, 
'Doświadczenie autora w naturoterapii sięga już przeszło dwudziestu lat. Zagadnieniem, nad którym najwięcej w tym czasie pracował, były naturalne metody leczenia i zapobiegania przewlekłym nowotworom. Lata badań i analiz przyczyniły się do powstania „Ukrytych terapii” i innych publikacji, nieznanych jak dotąd medycznym środowiskom. Jerzy Zięba pozostaje na tym polu aktywny. Oprócz licznych publikacji w prasie, prowadzi też wykłady z naturoterapii, jest dyplomowanym hipnoterapeutą w Australii i USA oraz tłumaczem książki „Cholesterol – naukowe kłamstwo”.
 
„Ukryte terapie” to przede wszystkim bogate i solidne udokumentowanie śmiałych, popartych badaniami teorii. Nie ma tu miejsca na domysły, domniemania czy myślenie życzeniowe, a całość podana jest czytelnikowi w sposób zrozumiały i intrygujący już od pierwszej strony. Pomaga wszystkim bez wyjątku, a najbardziej tym, wobec których farmakologiczne leczenie wyczerpało już swoje możliwości.', 
43.20, 1000);

if not exists(select * from Book where TitleForDisplay like 'Królowa' and ISBN like '9788365521385')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, BookSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Królowa', 'Krolowa', (select Id from Publishing where NameForDisplay like 'Zysk i S-ka'), 
'2016-01-01', '9788365521385', 600, '14.9x22.9x3.6 cm',
'http://www.taniaksiazka.pl/images/popups/5B6/9788365521385.jpg', 0, 0, 0, 
'Nigdy nie wiesz, kto się za ciebie modli.

Narodził się Knut. Trzecie dziecko Świętosławy, jedyne, które w chwili przyjścia na świat okrzyknięto "synem królowej”. Coraz więcej graczy przestawia piony tej historii. Bolesław w sekrecie przed siostrą swata Tyrę z Tryggvasonem, jarl Sigvald, powtarzając: "jomswikingowie nie wtrącają się w sprawy królów”, sam zaczyna w nich mieszać. Sven pielęgnuje swą niechęć do Olava, "drugiego wodza”. Tyra znika.

Tak kończy się Harda. Teraz nadchodzi czas Królowej. Nowi gracze i nowy wymiar tej historii. Od Roskilde do krainy zórz polarnych. Od Poznania przez Merseburg do Budziszyna, przez wszystkie wielkie wojny Bolesława. Od Pragi po Kijów. Od Gniezna przez tajemniczy Kałdus. I do Anglii, bo przecież nie jest tajemnicą, kim stanie się "syn królowej"...

Nikt przed nią nie opowiadał o naszych początkach tak świetnie.
- Krzysztof Masłoń, "Do Rzeczy"

Ciąg dalszy porywającej opowieści o Świętosławie. Wciągające od pierwszego słowa do ostatniej kropki. Elżbieta Cherezińska wie, jak zaczarować i oczarować czytelnika. Nie można przestać czytać.
- Michał Nogaś, Program 3 Polskiego Radia

Zaczyna się od trzęsienia ziemi, a potem autorka pozwala się rozpętać innym żywiołom. Królowa polskiej powieści historycznej wydobywa z mroku dziejów, dawnych kronik, sag i legend postać innej królowej - żywą i pełnokrwistą. Wielkie namiętności i ambicje, gniew, zdrada, zemsta i "szczegóły, których spowiednik wolałby nigdy nie usłyszeć”. Bezsenne noce spędzone nad lekturą Królowej gwarantowane.
- Mateusz Trojan, "Teleexpress"', 
31.52, 1000);

if not exists(select * from Book where TitleForDisplay like 'Uwikłani Tom 1. Pokusa' and ISBN like '9788365170163')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Uwikłani Tom 1. Pokusa', 'Uwiklani-Tom-1-Pokusa', (select Id from Publishing where NameForDisplay like 'Kobiece'), 
'2015-10-12', '9788365170163', 360, 'http://www.taniaksiazka.pl/images/popups/306/@9788365170163.jpg', 1, 0, 2,
'Rycerz Siedmiu Królestw to prawdziwa gratka dla wszystkich miłośników George`a R.R. Martina i jego Gry o tron. Osadzone w świecie cyklu Pieśń Lodu i Ognia trzy minipowieści (Wędrowny rycerz, Zaprzysiężony miecz, Tajemniczy rycerz) prezentują wszystko to, co przyniosło autorowi światową sławę - fascynującą "rycerską" fabułę, nakreślone wiarygodnie psychologicznie postaci, rubaszny humor i niespodziewane zwroty akcji, a wszystko to okraszone odrobiną unoszącej się nad krainami Westeros smoczej magii.

Rycerskie turnieje, zhańbione damy, dworskie intrygi - to codzienne życie młodzieńca imieniem Dunk, który po śmierci swego rycerza wyrusza na turniej w poszukiwaniu sławy oraz honoru, nie wiedząc, że świat nie jest gotowy na przyjęcie kogoś, kto dotrzymuje przysiąg. W kolejnych częściach Dunk oraz jego kumpel Jajo (późniejszy Aegon V Targaryen, książę Westeros, król i obrońca królestwa) wmieszają się w konflikt ser Eustace`a Osgreya ze Standfast z lady Webber z Zimnej Fosy, a także przybędą na ślub lorda Ambrose`a Butterwella z Białych Murów, gdzie Dunk stanie do turnieju jako Tajemniczy Rycerz, nieświadomy prawdziwego charakteru rozgrywających się wydarzeń...', 
25.50, 1000);

if not exists(select * from Book where TitleForDisplay like 'Rycerz Siedmiu Królestw' and ISBN like '9788377854167')
insert into Book(TitleForDisplay, Title, PublishingId, PublishDate, ISBN, PageSize, [Image], Bestseller, [Language], Cover, [Description],  Price, Quantity) 
values('Rycerz Siedmiu Królestw', 'Rycerz-Siedmiu-Krolestw', (select Id from Publishing where NameForDisplay like 'Zysk i S-ka'), 
'2016-01-01', '9788377854167', 300, 'http://www.taniaksiazka.pl/images/large/F52/@9788377854167_52.jpg', 1, 0, 2,
'ELEKTRYZUJĄCA… HIPNOTYZUJĄCA… FASCYNUJĄCA…
KSIĄŻKA, O KTÓREJ MÓWIĄ WSZYSCY!

Ona zatraca się w swoich chorobliwych obsesjach.
On skrywa mroczne tajemnice z przeszłości.


Młoda, piękna i niezwykle inteligentna Alayna Withers właśnie obroniła tytuł MBA na prestiżowej nowojorskiej uczelni. Pracuje w klubie nocnym i marzy o awansie na stanowisko menedżera. Z mocnym postanowieniem stara się trzymać z dala od mężczyzn wyzwalających w niej chorobliwą obsesję miłosną, przez którą popadła w problemy z prawem.

Alayna jest pewna, że nic nie jest w stanie zakłócić jej doskonałego planu. Nie przewidziała jednak, że na jej drodze, w najmniej oczekiwanym momencie, stanie diabelnie przystojny miliarder Hudson Pierce – nowy właściciel klubu nocnego, w którym pracuje Alanya. Mężczyzna od pierwszych chwil zawładnie sercem kobiety, która nie będzie potrafiła oprzeć się wszechogarniającej mieszance uczuć.

Wkrótce Hudson składa Alaynie propozycję nie do odrzucenia. Wybuch pasji między nimi sprawi, że kobieta ulegnie silnemu uczuciu, budząc głęboko skrywane grzechy przeszłości. Nie tylko swoje…


Czy mroczna przeszłość kochanków przeszkodzi im w walce o wspólną przyszłość?


"Czytaj w klimatyzowanym pomieszczeniu, bo będzie GORĄCO".

- Melanie Harlow, autorka Speak Easy

"Ta książka całkowicie mną zawładnęła".

- Emma Hart, bestsellerowa autorka książki The Love Game', 
18.68, 1000);