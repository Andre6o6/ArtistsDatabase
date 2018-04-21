INSERT INTO public.artist (artist_id, first_name, last_name) VALUES
    (1, 'Leo', 'Davinchi'),
	(2, 'Kazimir', 'Malevich'),
	(3, 'Michelangelo', 'Buonarroti'),
	(4, 'Ivan', 'Shishkin'),
	(5, 'Karl', 'Bryullov'),
	(6, 'Pierre', 'Mignard'),
	(7, 'Carlos-Eduardo', 'Berganza'),
	(8, 'Gray-Skull', null),
	(9, 'Walid', 'Feghali'),
	(10, 'Sakimichan', null);

INSERT INTO public.internet_site VALUES
	(1, 'deviantart.com'),
	(2, 'tumblr.com'),
	(3, 'patreon.com'),
	(4, 'fineartamerica.com'),
	(5, 'walidfeghali.com'),
	(6, 'gallerix.ru');
	
INSERT INTO public.artist_site (artist_id, site_id, username) VALUES
	(1, 4, null),
	(3, 4, null),
	(6, 4, null),
	(2, 6, null),
	(4, 6, null),
	(5, 6, null),
	(7, 1, 'Raichiyo33'),
	(7, 2, 'Raichiyo33'),
	(7, 3, 'Raichiyo33'),
	(8, 2, 'gray-skull-art'),
	(9, 5, null),
	(10, 1, 'Sakimichan'),
	(10, 3, 'Sakimichan');
	
INSERT INTO public.painting (painting_id, title, technique, artist_id) VALUES	
	(1, 'Mona Lisa', 'oil on panel', 1),
	(2, 'Чёрный супрематический квадрат', 'oil', 2),
	(3, 'The Creation of Adam', 'fresco', 3),
	(4, 'Утро в сосновом лесу', 'oil on canvas', 4),
	(5, 'Последний день Помпеи', 'oil on canvas', 5),
	(6, 'The Death of Cleopatra', 'oil on canvas', 6),
	(7, 'Рожь', null, 4),
	(8, 'Всадница', null, 5),
	(9, 'At the Stream of Light', 'digital',9),
	(10,'Blárlandi Fjord', 'digital',9);
	
INSERT INTO public.painting_exhibition (is_original, exhibition_id, painting_id) VALUES	
	(1, 1, 1),
	(0, 2, 1),
	(0, 4, 1),
	(1, 2, 2),
	(1, 2, 4),
	(0, 3, 4),
	(1, 3, 5),
	(1, 4, 6),
	(1, 2, 7),
	(1, 2, 8);
	
INSERT INTO public.exhibition VALUES	
	(1, 'Louvre', 1),
	(2, 'Третьяковская галерея', 2),
	(3, 'Государственный Русский музей', 3),
	(4, 'National trust collection', 4);
	
	
INSERT INTO public.auction VALUES	
	(1, 'Sothebys', 5),
	(2, 'Аукционъ', 6);
	
INSERT INTO public.painting_auction (starting_price, painting_id, auction_id) VALUES	
	(100000, 1, 1),
	(50, 10, 1),
	(1000, 8, 2);
	
INSERT INTO public.address (address_id, address, city_id) VALUES	
	(1, 'Louvre Museum', 1),
	(2, 'Лаврушинский переулок, 10', 2),
	(3, 'Инженерная ул., 4', 3),
	(4, 'Chirk Castle', 4),
	(5, 'Аукционская ул., 1', 3),
	(6, 'Newland Ave. 11', 5);	
	
INSERT INTO public.city (city_id, city, country_id) VALUES	
	(1, 'Paris', 1),
	(2, 'Moscow', 2),
	(3, 'Saint Petersburg', 2),
	(4, 'Wrexham', 3),
	(5, 'New York', 4);	
	
INSERT INTO public.country VALUES
	(1,'France'),
	(2,'Russia'),
	(3,'Wales'),
	(4,'USA');
	