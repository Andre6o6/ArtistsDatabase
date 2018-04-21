CREATE TABLE public.artist
(
  artist_id INT NOT NULL,
  first_name VARCHAR(20) NOT NULL,
  last_name VARCHAR(20),
  PRIMARY KEY (artist_id)
);

CREATE TABLE public.painting
(
  painting_id INT NOT NULL,
  title VARCHAR(50) NOT NULL,
  technique VARCHAR(50),
  year INT,
  artist_id INT NOT NULL,
  PRIMARY KEY (painting_id),
  FOREIGN KEY (artist_id) REFERENCES Artist(artist_id)
);

CREATE TABLE public.internet_site
(
  site_id INT NOT NULL,
  site VARCHAR(20) NOT NULL,
  PRIMARY KEY (site_id)
);

CREATE TABLE public.country
(
  country_id INT NOT NULL,
  country VARCHAR(20) NOT NULL,
  PRIMARY KEY (country_id)
);

CREATE TABLE public.artist_site
(
  username VARCHAR(20),
  artist_id INT NOT NULL,
  site_id INT NOT NULL,
  PRIMARY KEY (artist_id, site_id),
  FOREIGN KEY (artist_id) REFERENCES Artist(artist_id),
  FOREIGN KEY (site_id) REFERENCES Internet_site(site_id)
);

CREATE TABLE public.city
(
  city_id INT NOT NULL,
  city VARCHAR(20) NOT NULL,
  country_id INT NOT NULL,
  PRIMARY KEY (city_id),
  FOREIGN KEY (country_id) REFERENCES Country(country_id)
);

CREATE TABLE public.address
(
  address_id INT NOT NULL,
  address VARCHAR(50) NOT NULL,
  district VARCHAR(20),
  postal_code VARCHAR(10),
  phone VARCHAR(20),
  city_id INT NOT NULL,
  PRIMARY KEY (address_id),
  FOREIGN KEY (city_id) REFERENCES City(city_id)
);

CREATE TABLE public.exhibition
(
  exhibition_id INT NOT NULL,
  exhibition_name VARCHAR(50),
  address_id INT NOT NULL,
  PRIMARY KEY (exhibition_id),
  FOREIGN KEY (address_id) REFERENCES Address(address_id)
);

CREATE TABLE public.auction
(
  auction_id INT NOT NULL,
  auction_name VARCHAR(50),
  address_id INT NOT NULL,
  PRIMARY KEY (auction_id),
  FOREIGN KEY (address_id) REFERENCES Address(address_id)
);

CREATE TABLE public.painting_exhibition
(
  is_original INT NOT NULL,
  exhibition_id INT NOT NULL,
  painting_id INT NOT NULL,
  PRIMARY KEY (exhibition_id, painting_id),
  FOREIGN KEY (exhibition_id) REFERENCES Exhibition(exhibition_id),
  FOREIGN KEY (painting_id) REFERENCES Painting(painting_id)
);

CREATE TABLE public.painting_auction
(
  starting_price INT,
  painting_id INT NOT NULL,
  auction_id INT NOT NULL,
  PRIMARY KEY (painting_id, auction_id),
  FOREIGN KEY (painting_id) REFERENCES Painting(painting_id),
  FOREIGN KEY (auction_id) REFERENCES Auction(auction_id)
);