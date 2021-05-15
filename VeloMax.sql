drop database if exists veloMax;
CREATE DATABASE veloMax;
use veloMax;

-- CREATION TABLES

CREATE TABLE Fournisseur(
	siret_fournisseur varchar(30) not null PRIMARY KEY,
	nom_fournisseur VARCHAR(20) NOT NULL,
    contact_fournisseur VARCHAR(20) NOT NULL,
    adresse_fournisseur VARCHAR(100) NOT NULL,
    note_fournisseur int
	);
    
    CREATE TABLE Piece(
	no_piece varchar(20) not null PRIMARY KEY,
	desc_piece varchar(20) not null,
    date_intro_piece varchar(20) not null,
    date_disco_piece varchar(20) not null,
    stock int check (stock >0)
	);
    
    CREATE TABLE Livraison(
	siret_fournisseur varchar(30) not null,
    FOREIGN KEY (siret_fournisseur) REFERENCES Fournisseur(siret_fournisseur),
	no_piece VARCHAR(20) NOT NULL,
    FOREIGN KEY (no_piece) REFERENCES Piece(no_piece),
    delai_approvisionnement VARCHAR(20) NOT NULL,
    prix_piece int NOT NULL,
    no_piece_fournisseur varchar(20) not null,
    primary key (siret_fournisseur,no_piece)
	);
    
	CREATE TABLE Boutique(
	no_boutique int not null PRIMARY KEY,
    nom_boutique varchar(20) not null,
    adresse_boutique VARCHAR(50) NOT NULL,
    tel_boutique varchar(20) NOT NULL,
    mail_boutique varchar(20) not null,
    contact_boutique varchar(20) not null,
    remise_boutique int
	);
    CREATE TABLE Commande(
	no_commande int not null PRIMARY KEY,
    date_commande varchar(20) not null,
    adresse_livraison varchar(50) not null,
    date_livraison varchar(20) not null
	);
    CREATE TABLE DevisBoutique(
	no_commande int not null ,
    foreign key(no_commande) references Commande(no_commande),
    no_boutique int not null,
    foreign key(no_boutique) references Boutique(no_boutique),
    primary key(no_commande,no_boutique)
	);
    
    
    
    
    
  CREATE TABLE Programme(
	no_programme int  PRIMARY KEY,
	description_programme VARCHAR(15),
	prix_programme int NOT NULL,
	duree_programme int NOT NULL,
    rabais_programme int NOT NULL
	);  
CREATE TABLE Particulier(
	no_particulier int  PRIMARY KEY,
	nom_particulier VARCHAR(40) NOT NULL,
    prenom_particulier VARCHAR(40) NOT NULL,
    adresse_particulier VARCHAR(100),
	tel_particulier VARCHAR(10),
	mail_particulier VARCHAR(100),
    date_souscription varchar(20) not null,
	no_programme int,
    FOREIGN KEY (no_programme) REFERENCES Programme(no_programme)
	);
    CREATE TABLE DevisParticulier(
	no_particulier int ,
    foreign key(no_particulier) references Particulier(no_particulier),
    no_commande int,
    foreign key(no_commande) references Commande(no_commande),
    primary key(no_particulier,no_commande)
	);

    


    
CREATE TABLE Modele(
	no_modele int  PRIMARY KEY,
	nom_modele VARCHAR(14) NOT NULL,
    grandeur VARCHAR(7) NOT NULL,
    prix_modele int NOT NULL,
	ligne VARCHAR(14) NOT NULL,
	date_intro_modele varchar(20) not null,
    date_disco_modele varchar(20) not null
	);


    
    CREATE TABLE CommandeModele(
	no_commande int  ,
    foreign key(no_commande) references Commande(no_commande),
    no_modele int ,
    foreign key(no_modele) references Modele(no_modele),
    primary key(no_commande,no_modele)
	);
    
    CREATE TABLE CommandePiece(
	no_commande int not null ,
    foreign key(no_commande) references Commande(no_commande),
    no_piece varchar(20) ,
    foreign key(no_piece) references Piece(no_piece),
    qte_piece_commande int, 
    primary key(no_commande,no_piece,qte_piece_commande)
	);
    
    CREATE TABLE Production(
	no_modele int  ,
    foreign key(no_modele) references Modele(no_modele),
    no_piece varchar(20) not null ,
    foreign key(no_piece) references Piece(no_piece),
    primary key (no_modele,no_piece)
	);

    
    -- INSERTION
INSERT INTO Fournisseur VALUES ('36252187900034','Arcade','Jean Arcade','5 rue des pompes,Paris', 1);
INSERT INTO Fournisseur VALUES ('38272090000478','BMC','Camille BMC', '10 rue claudel, Paris', 2);
INSERT INTO Fournisseur VALUES ('44582362107759','Cycleurope','Lucie Cycleurope', '20 avenue de la republique,Paris',3);
    
INSERT INTO Piece VALUES ("C32", 'Cadre', 30/05/2020, 20/07/2021, 29);
INSERT INTO Piece VALUES ("C34", 'Cadre',20/05/2020, 30/07/2021, 40);
INSERT INTO Piece VALUES ("C76", 'Cadre',30/06/2020, 20/08/2021, 40);
INSERT INTO Piece VALUES ("C44f", 'Cadre', 16/05/2020, 17/07/2021,29);
INSERT INTO Piece VALUES ("C43", 'Cadre', 18/07/2020, 20/07/2022,25);
INSERT INTO Piece VALUES ("C43f", 'Cadre', 30/05/2020, 20/07/2023,25);
INSERT INTO Piece VALUES ("C01", 'Cadre', 10/09/2020, 20/09/2021,79);


INSERT INTO Piece VALUES ("C02", 'Cadre',30/05/2020, 20/07/2021, 54);
INSERT INTO Piece VALUES ("C15", 'Cadre',25/02/2020, 20/01/2022, 15);
INSERT INTO Piece VALUES ("C87", 'Cadre', 30/08/2020, 01/07/2022,20);
INSERT INTO Piece VALUES ("C87f", 'Cadre',03/05/2020, 20/10/2021, 21);
INSERT INTO Piece VALUES ("C25", 'Cadre',05/05/2020, 20/12/2022, 40);
INSERT INTO Piece VALUES ("C26", 'Cadre',06/09/2020, 20/09/2023, 34);

INSERT INTO Piece VALUES ("G7", 'Guidon',15/11/2020, 20/07/2023, 31);
INSERT INTO Piece VALUES ("G9", 'Guidon',30/10/2020, 20/10/2022, 57);
INSERT INTO Piece VALUES ("G12", 'Guidon', 30/11/2020, 20/11/2021,27);

INSERT INTO Piece VALUES ("F3", 'Freins',15/02/2020, 20/07/2022, 52);
INSERT INTO Piece VALUES ("F9", 'Freins',16/04/2020, 20/08/2021, 67);

INSERT INTO Piece VALUES ("S88", 'Selle',01/01/2020, 20/009/2021, 31);
INSERT INTO Piece VALUES ("S37", 'Selle',05/11/2020, 05/12/2023, 29);
INSERT INTO Piece VALUES ("S35", 'Selle',14/05/2020, 20/07/2021, 35);
INSERT INTO Piece VALUES ("S02", 'Selle',16/03/2020, 20/03/2021, 40);
INSERT INTO Piece VALUES ("S03", 'Selle',30/05/2020, 20/07/2021, 31);
INSERT INTO Piece VALUES ("S36", 'Selle', 17/05/2020, 17/07/2022,30);
INSERT INTO Piece VALUES ("S34", 'Selle',12/01/2020, 20/01/2023, 38);
INSERT INTO Piece VALUES ("S87", 'Selle',16/06/2020, 20/08/2021, 31);

INSERT INTO Piece VALUES ("DV133", 'Dérailleur Avant',30/05/2020, 20/07/2021, 33);
INSERT INTO Piece VALUES ("DV17", 'Dérailleur Avant', 30/01/2020, 20/01/2021,34);
INSERT INTO Piece VALUES ("DV87", 'Dérailleur Avant',19/09/2020, 20/09/2021, 30);
INSERT INTO Piece VALUES ("DV57", 'Dérailleur Avant', 30/06/2020, 20/07/2025,26);
INSERT INTO Piece VALUES ("DV41", 'Dérailleur Avant',01/01/2020, 02/07/2021, 26);
INSERT INTO Piece VALUES ("DV132", 'Dérailleur Avant',30/02/2020, 20/06/2023, 28);
INSERT INTO Piece VALUES ("DV56", 'Dérailleur Avant',30/02/2020, 20/06/2023, 28);
INSERT INTO Piece VALUES ("DV15", 'Dérailleur Avant',30/02/2020, 20/06/2023, 28);

INSERT INTO Piece VALUES ("DR56", 'Dérailleur Arrière',30/05/2020, 20/07/2021, 22);
INSERT INTO Piece VALUES ("DR87", 'Dérailleur Arrière',15/05/2020, 20/05/2021, 25);
INSERT INTO Piece VALUES ("DR86", 'Dérailleur Arrière', 03/05/2020, 03/07/2022,30);
INSERT INTO Piece VALUES ("DR23", 'Dérailleur Arrière', 30/05/2020, 20/07/2021,26);
INSERT INTO Piece VALUES ("DR76", 'Dérailleur Arrière', 30/10/2020, 20/10/2021,30);
INSERT INTO Piece VALUES ("DR52", 'Dérailleur Arrière', 05/11/2020, 20/11/2021,35);

INSERT INTO Piece VALUES ("R45", 'Roue avant',30/05/2020, 20/07/2021, 40);
INSERT INTO Piece VALUES ("R48", 'Roue avant',18/08/2020, 20/09/2023, 37);
INSERT INTO Piece VALUES ("R12", 'Roue avant', 19/05/2020, 20/09/2021,30);
INSERT INTO Piece VALUES ("R19", 'Roue avant',16/01/2020, 14/09/2021, 40);
INSERT INTO Piece VALUES ("R1", 'Roue avant',17/05/2020, 20/07/2021, 32);
INSERT INTO Piece VALUES ("R11", 'Roue avant',25/05/2020, 22/07/2022, 33);
INSERT INTO Piece VALUES ("R44", 'Roue avant', 29/04/2020, 20/04/2023,25);

INSERT INTO Piece VALUES ("R46", 'Roue arrière',30/05/2020, 20/07/2021, 45);
INSERT INTO Piece VALUES ("R32", 'Roue arrière',02/02/2020, 08/08/2021, 25);
INSERT INTO Piece VALUES ("R18", 'Roue arrière',12/12/2020, 12/12/2023, 24);
INSERT INTO Piece VALUES ("R2", 'Roue arrière', 11/02/2020, 20/07/2021,33);
INSERT INTO Piece VALUES ("R13", 'Roue arrière', 30/05/2020, 20/07/2021,35);
INSERT INTO Piece VALUES ("R47", 'Roue arrière',14/12/2020, 20/12/2021, 33);

INSERT INTO Piece VALUES ("R02", 'Réflecteurs',30/05/2020, 20/07/2021, 30);
INSERT INTO Piece VALUES ("R09", 'Réflecteurs',15/01/2020, 20/01/2021, 39);
INSERT INTO Piece VALUES ("R10", 'Réflecteurs', 30/08/2020, 20/11/2021,46);

INSERT INTO Piece VALUES ("P12", 'Pédalier',30/05/2020, 20/07/2022, 26);
INSERT INTO Piece VALUES ("P34", 'Pédalier',16/11/2020, 20/12/2023, 36);
INSERT INTO Piece VALUES ("P1", 'Pédalier',06/05/2020, 06/07/2021, 20);
INSERT INTO Piece VALUES ("P15", 'Pédalier',30/11/2020, 20/12/2021, 18);

INSERT INTO Piece VALUES ("O2", 'Ordinateur', 30/05/2020, 20/07/2021,27);
INSERT INTO Piece VALUES ("O4", 'Ordinateur',30/05/2020, 20/05/2023, 22);

INSERT INTO Piece VALUES ("S01", 'Panier', 30/05/2020, 20/07/2021,37);
INSERT INTO Piece VALUES ("S05", 'Panier',15/05/2020, 15/07/2024, 30);
INSERT INTO Piece VALUES ("S74", 'Panier', 14/11/2020, 20/11/2021,27);
INSERT INTO Piece VALUES ("S73", 'Panier', 30/05/2020, 20/07/2021,22);

INSERT INTO Livraison VALUES ("44582362107759", 'S01', 15, 50,'S01');
INSERT INTO Livraison VALUES ("44582362107759", 'O2', 10, 25,'02');
INSERT INTO Livraison VALUES ("44582362107759", 'P15', 10, 25,'P15');
INSERT INTO Livraison VALUES ("44582362107759", 'R10', 10, 5,'R10');
INSERT INTO Livraison VALUES ("38272090000478", 'R32', 5, 30,'R32');
INSERT INTO Livraison VALUES ("38272090000478", 'R12', 5, 30,'R12');
INSERT INTO Livraison VALUES ("38272090000478", 'DR23', 20, 40,'DR23');
INSERT INTO Livraison VALUES ("36252187900034", 'DV17', 5, 30,'DV17');
INSERT INTO Livraison VALUES ("36252187900034", 'S03', 15, 50,'S03');
INSERT INTO Livraison VALUES ("36252187900034", 'F9', 5, 30,'F9');
INSERT INTO Livraison VALUES ("36252187900034", 'G12', 5, 30,'G12');
INSERT INTO Livraison VALUES ("38272090000478", 'C32', 10, 12,'R32');

INSERT INTO Boutique VALUES ("01234", 'Ecox','3 rue de la paix, Paris', 0123455678,'ecox@gmail.com','Pierre Ecox',10);
INSERT INTO Boutique VALUES ("12345", 'Cyclewear','12 rue de la joie, Paris', 0154875985,'cyclewear@gmail.com','Jeanne Cyclewear',10);
INSERT INTO Boutique VALUES ("56789", 'Solicycle','12 rue Mozart, Paris', 0165450113,'solicycle@gmail.com','Jeane Cyclewear',10);

insert into Commande values('12548', 30/05/2020,' 22 rue de la manufacture, Paris', 20/07/2020);
insert into Commande values('12549', 02/06/2020,' 22 rue Jouot, Mulhouse', 20/08/2020);
insert into Commande values('12550', 05/06/2020,' 14 boulevard malsherbes, Paris', 15/06/2020);
insert into Commande values('12551', 10/06/2020,' 2 rue de rennes, Paris', 02/08/2020);
insert into Commande values('12552', 12/06/2020,' 56 rue de Marseilles, Clermont-Ferrand', 20/07/2020);

insert into DevisBoutique values ('12551',"01234");
insert into DevisBoutique values ('12550',"01234");
insert into DevisBoutique values ('12549',"12345");
insert into DevisBoutique values ('12548',"56789");


INSERT INTO Programme VALUES (1,'Fidélio',15,1,5);
INSERT INTO Programme VALUES (2,'Fidélio Or',25,2,8);
INSERT INTO Programme VALUES (3,'Fidélio Platine',60,2,10);
INSERT INTO Programme VALUES (4,'Fidélio Max',100,3,12);
INSERT INTO Programme VALUES (0,null,100,3,12);

insert into Particulier values('13','Keener','Jeremy','3 rue de vileneuve, Maurepas','0689747756','jeremy@keener.com', 10/05/2021,'1');
insert into Particulier values('14','Geron','Paul','3 rue basse, Versailles','0645896257','paul@geron.com', 15/07/2021,'2');
insert into Particulier values('15','Blanc','Pauline','4 rue basse, Versailles','0625348759','pauline@blanc.com', 17/07/2021,'3');
insert into Particulier values('16','Grand','Matthieu','10 rue leonard de vinci, Courbevoie','0745256142','matthieu@grand.com', 20/07/2021,'4');
insert into Particulier values('18','Jugnot','Gerard','20 rue giron, Aix-en-provence','0665447747','gerard@jugnot.com', 28/09/2020,'0');


insert into DevisParticulier values ('13','12548');
insert into DevisParticulier values ('14','12549');
insert into DevisParticulier values ('15','12550');


INSERT INTO Modele VALUES (101,'Kilimandjaro','Adultes',569,'VTT',01/04/2021,01/04/2026);
INSERT INTO Modele VALUES (102,'NorthPole','Adultes',329,'VTT',01/04/2021,01/04/2026);
INSERT INTO Modele VALUES (103,'MontBlanc','Jeunes',399,'VTT',01/04/2021,01/04/2026);
INSERT INTO Modele VALUES (104,'Hooligan','Jeunes',199,'VTT',01/04/2021,01/04/2026);
INSERT INTO Modele VALUES (105,'Orléans','Hommes',229,'Vélo de course',28/04/2017,28/04/2022);
INSERT INTO Modele VALUES (106,'Orléans','Dames',229,'Vélo de course',28/04/2017,28/04/2022);
INSERT INTO Modele VALUES (107,'BlueJay','Hommes',349,'Vélo de course',28/04/2017,28/04/2022);
INSERT INTO Modele VALUES (108,'BlueJay','Dames',349,'Vélo de course',28/04/2017,28/04/2022);
INSERT INTO Modele VALUES (109,'Trail Explorer','Filles',129,'Classique',23/09/2020,23/09/2025);
INSERT INTO Modele VALUES (110,'Trail Explorer','Garçons',129,'Classique',23/09/2020,23/09/2025);
INSERT INTO Modele VALUES (111,'Night Hawk','Jeunes',189,'Classique',23/09/2020,23/09/2025);
INSERT INTO Modele VALUES (112,'Tierra Verde','Hommes',199,'Classique',23/09/2020,23/09/2025);
INSERT INTO Modele VALUES (113,'Tierra Verde','Dames',199,'Classique',23/09/2020,23/09/2025);
INSERT INTO Modele VALUES (114,'Mud Zinger I','Jeunes',279,'BMX',07/02/2018,07/02/2023);
INSERT INTO Modele VALUES (115,'Mud Zinger II','Adultes',359,'BMX',07/02/2018,07/02/2023);

INSERT INTO CommandeModele VALUES (12548,111);
INSERT INTO CommandeModele VALUES (12549,102);
INSERT INTO CommandeModele VALUES (12550,114);
INSERT INTO CommandeModele VALUES (12551,106);
INSERT INTO CommandeModele VALUES (12552,101);

INSERT INTO Production VALUES ('101','C32');
INSERT INTO Production VALUES ('101','G7');
INSERT INTO Production VALUES ('101','F3');
INSERT INTO Production VALUES ('101','S88');
INSERT INTO Production VALUES ('101','DV133');
INSERT INTO Production VALUES ('101','DR56');
INSERT INTO Production VALUES ('101','R45');
INSERT INTO Production VALUES ('101','R46');
INSERT INTO Production VALUES ('101','P12');
INSERT INTO Production VALUES ('101','O2');

INSERT INTO Production VALUES ('102','C34');
INSERT INTO Production VALUES ('102','G7');
INSERT INTO Production VALUES ('102','F3');
INSERT INTO Production VALUES ('102','S88');
INSERT INTO Production VALUES ('102','DV17');
INSERT INTO Production VALUES ('102','DR87');
INSERT INTO Production VALUES ('102','R48');
INSERT INTO Production VALUES ('102','R47');
INSERT INTO Production VALUES ('102','P12');
INSERT INTO Production VALUES ('102','O2');

INSERT INTO Production VALUES ('103','C76');
INSERT INTO Production VALUES ('103','G7');
INSERT INTO Production VALUES ('103','F3');
INSERT INTO Production VALUES ('103','S88');
INSERT INTO Production VALUES ('103','DV17');
INSERT INTO Production VALUES ('103','DR87');
INSERT INTO Production VALUES ('103','R48');
INSERT INTO Production VALUES ('103','R47');
INSERT INTO Production VALUES ('103','P12');
INSERT INTO Production VALUES ('103','O2');

INSERT INTO Production VALUES ('104','C76');
INSERT INTO Production VALUES ('104','G7');
INSERT INTO Production VALUES ('104','F3');
INSERT INTO Production VALUES ('104','S88');
INSERT INTO Production VALUES ('104','DV87');
INSERT INTO Production VALUES ('104','DR86');
INSERT INTO Production VALUES ('104','R19');
INSERT INTO Production VALUES ('104','R18');
INSERT INTO Production VALUES ('104','P12');

INSERT INTO Production VALUES ('105','C43');
INSERT INTO Production VALUES ('105','G9');
INSERT INTO Production VALUES ('105','F9');
INSERT INTO Production VALUES ('105','S37');
INSERT INTO Production VALUES ('105','DV57');
INSERT INTO Production VALUES ('105','DR86');
INSERT INTO Production VALUES ('105','R19');
INSERT INTO Production VALUES ('105','R18');
INSERT INTO Production VALUES ('105','R02');
INSERT INTO Production VALUES ('105','P34');

INSERT INTO Production VALUES ('106','C44f');
INSERT INTO Production VALUES ('106','G9');
INSERT INTO Production VALUES ('106','F9');
INSERT INTO Production VALUES ('106','S35');
INSERT INTO Production VALUES ('106','DV57');
INSERT INTO Production VALUES ('106','DR86');
INSERT INTO Production VALUES ('106','R19');
INSERT INTO Production VALUES ('106','R18');
INSERT INTO Production VALUES ('106','R02');
INSERT INTO Production VALUES ('106','P34');

INSERT INTO Production VALUES ('107','C43');
INSERT INTO Production VALUES ('107','G9');
INSERT INTO Production VALUES ('107','F9');
INSERT INTO Production VALUES ('107','S37');
INSERT INTO Production VALUES ('107','DV57');
INSERT INTO Production VALUES ('107','DR87');
INSERT INTO Production VALUES ('107','R19');
INSERT INTO Production VALUES ('107','R18');
INSERT INTO Production VALUES ('107','R02');
INSERT INTO Production VALUES ('107','P34');
INSERT INTO Production VALUES ('107','O4');

INSERT INTO Production VALUES ('108','C43f');
INSERT INTO Production VALUES ('108','G9');
INSERT INTO Production VALUES ('108','F9');
INSERT INTO Production VALUES ('108','S35');
INSERT INTO Production VALUES ('108','DV57');
INSERT INTO Production VALUES ('108','DR87');
INSERT INTO Production VALUES ('108','R19');
INSERT INTO Production VALUES ('108','R18');
INSERT INTO Production VALUES ('108','R02');
INSERT INTO Production VALUES ('108','P34');
INSERT INTO Production VALUES ('108','O4');

INSERT INTO Production VALUES ('109','C01');
INSERT INTO Production VALUES ('109','G12');
INSERT INTO Production VALUES ('109','S02');
INSERT INTO Production VALUES ('109','R1');
INSERT INTO Production VALUES ('109','R2');
INSERT INTO Production VALUES ('109','R09');
INSERT INTO Production VALUES ('109','P1');
INSERT INTO Production VALUES ('109','S01');

INSERT INTO Production VALUES ('110','C02');
INSERT INTO Production VALUES ('110','G12');
INSERT INTO Production VALUES ('110','S03');
INSERT INTO Production VALUES ('110','R1');
INSERT INTO Production VALUES ('110','R2');
INSERT INTO Production VALUES ('110','R09');
INSERT INTO Production VALUES ('110','P1');
INSERT INTO Production VALUES ('110','S05');

INSERT INTO Production VALUES ('111','C15');
INSERT INTO Production VALUES ('111','G12');
INSERT INTO Production VALUES ('111','F9');
INSERT INTO Production VALUES ('111','S36');
INSERT INTO Production VALUES ('111','DV15');
INSERT INTO Production VALUES ('111','DR23');
INSERT INTO Production VALUES ('111','R11');
INSERT INTO Production VALUES ('111','R12');
INSERT INTO Production VALUES ('111','R10');
INSERT INTO Production VALUES ('111','P15');
INSERT INTO Production VALUES ('111','S74');

INSERT INTO Production VALUES ('112','C87');
INSERT INTO Production VALUES ('112','G12');
INSERT INTO Production VALUES ('112','F9');
INSERT INTO Production VALUES ('112','S36');
INSERT INTO Production VALUES ('112','DV41');
INSERT INTO Production VALUES ('112','DR76');
INSERT INTO Production VALUES ('112','R11');
INSERT INTO Production VALUES ('112','R12');
INSERT INTO Production VALUES ('112','R10');
INSERT INTO Production VALUES ('112','P15');
INSERT INTO Production VALUES ('112','S74');

INSERT INTO Production VALUES ('113','C87f');
INSERT INTO Production VALUES ('113','G12');
INSERT INTO Production VALUES ('113','F9');
INSERT INTO Production VALUES ('113','S34');
INSERT INTO Production VALUES ('113','DV41');
INSERT INTO Production VALUES ('113','DR76');
INSERT INTO Production VALUES ('113','R11');
INSERT INTO Production VALUES ('113','R12');
INSERT INTO Production VALUES ('113','R10');
INSERT INTO Production VALUES ('113','P15');
INSERT INTO Production VALUES ('113','S73');

INSERT INTO Production VALUES ('114','C25');
INSERT INTO Production VALUES ('114','G7');
INSERT INTO Production VALUES ('114','F3');
INSERT INTO Production VALUES ('114','S87');
INSERT INTO Production VALUES ('114','DV132');
INSERT INTO Production VALUES ('114','DR52');
INSERT INTO Production VALUES ('114','R44');
INSERT INTO Production VALUES ('114','R47');
INSERT INTO Production VALUES ('114','P12');

INSERT INTO Production VALUES ('115','C26');
INSERT INTO Production VALUES ('115','G7');
INSERT INTO Production VALUES ('115','F3');
INSERT INTO Production VALUES ('115','S87');
INSERT INTO Production VALUES ('115','DV133');
INSERT INTO Production VALUES ('115','DR52');
INSERT INTO Production VALUES ('115','R44');
INSERT INTO Production VALUES ('115','R47');
INSERT INTO Production VALUES ('115','P12');



select no_piece from Piece;







