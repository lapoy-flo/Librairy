CREATE TABLE bookGenre
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY,
	[description] VARCHAR(20) NOT NULL
)

CREATE TABLE musicGenre
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY,
	[description] VARCHAR(20) NOT NULL
)

CREATE TABLE book
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY,
	[titre] VARCHAR(20) NOT NULL,
	[autor] VARCHAR(50) NOT NULL,
	[id_genre] INT NOT NULL,
	[isbn] VARCHAR(20) NOT NULL,
	[available] TINYINT NOT NULL,
	CONSTRAINT fk_book_genre
		FOREIGN KEY (id_genre)
		REFERENCES bookGenre(id)
)

CREATE TABLE album
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY,
	[titre] VARCHAR(20) NOT NULL,
	[artist] VARCHAR(50) NOT NULL,
	[id_genre] INT NOT NULL,
	[available] TINYINT NOT NULL,
	CONSTRAINT fk_music_genre
		FOREIGN KEY (id_genre)
		REFERENCES musicGenre(id)
)

CREATE TABLE music
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY,
	[id_album] INT NOT NULL,
	[titre] VARCHAR(20) NOT NULL,
	CONSTRAINT fk_list_music
		FOREIGN KEY (id_album)
		REFERENCES album(id)
)