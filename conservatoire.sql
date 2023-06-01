-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : jeu. 01 juin 2023 à 21:20
-- Version du serveur : 10.4.24-MariaDB
-- Version de PHP : 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `conservatoire`
--

-- --------------------------------------------------------

--
-- Structure de la table `administrateur`
--

CREATE TABLE `administrateur` (
  `ID` int(11) NOT NULL,
  `PSEUDO` char(1) NOT NULL,
  `MAIL` text NOT NULL,
  `MDP` text NOT NULL,
  `DATE_CREATION` date NOT NULL,
  `DATE_CONNEXION` date NOT NULL,
  `NOM` text NOT NULL,
  `PRENOM` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `administrateur`
--

INSERT INTO `administrateur` (`ID`, `PSEUDO`, `MAIL`, `MDP`, `DATE_CREATION`, `DATE_CONNEXION`, `NOM`, `PRENOM`) VALUES
(1, '', 'celeste.terpin@admin.efrei.net', 'Dj5?3yPh!9', '0000-00-00', '0000-00-00', 'TERPIN', 'Céleste');

-- --------------------------------------------------------

--
-- Structure de la table `eleve`
--

CREATE TABLE `eleve` (
  `IDELEVE` int(11) NOT NULL,
  `BOURSE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `eleve`
--

INSERT INTO `eleve` (`IDELEVE`, `BOURSE`) VALUES
(1, 1200),
(2, 1500),
(7, 12),
(8, 0),
(9, 1200),
(10, 1200);

-- --------------------------------------------------------

--
-- Structure de la table `heure`
--

CREATE TABLE `heure` (
  `TRANCHE` char(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `heure`
--

INSERT INTO `heure` (`TRANCHE`) VALUES
('10h00-11h00'),
('10h00-12h00'),
('11h00-12h00'),
('13h00-14h00'),
('13h00-15h00'),
('14h00-15h00'),
('16h00-17h00'),
('16h00-18h00'),
('17h00-18h00'),
('18h00-19h00'),
('19h00-20h00'),
('8h00-10h00'),
('8h00-9h00'),
('9h00-10h00'),
('9h00-11h00');

-- --------------------------------------------------------

--
-- Structure de la table `inscription`
--

CREATE TABLE `inscription` (
  `IDPROF` int(11) NOT NULL,
  `IDELEVE` int(11) NOT NULL,
  `NUMSEANCE` int(11) NOT NULL,
  `DATEINSCRIPTION` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `inscription`
--

INSERT INTO `inscription` (`IDPROF`, `IDELEVE`, `NUMSEANCE`, `DATEINSCRIPTION`) VALUES
(3, 1, 10, '2023-05-13'),
(3, 2, 6, '2023-06-01'),
(3, 2, 22, NULL),
(3, 7, 22, '2023-06-01'),
(3, 8, 10, '2023-05-13'),
(3, 9, 6, '2023-05-13'),
(4, 1, 7, '2023-05-01'),
(4, 8, 7, '2023-05-13'),
(11, 1, 11, '2023-05-13'),
(11, 1, 17, '2023-06-01'),
(11, 1, 28, '2023-06-01'),
(11, 2, 17, NULL),
(11, 2, 23, '2023-06-01'),
(11, 7, 11, '2023-05-13'),
(11, 7, 17, '2023-06-01'),
(11, 8, 17, '2023-06-01'),
(11, 8, 23, '2023-06-01');

-- --------------------------------------------------------

--
-- Structure de la table `instrument`
--

CREATE TABLE `instrument` (
  `LIBELLE` char(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `instrument`
--

INSERT INTO `instrument` (`LIBELLE`) VALUES
('Flute'),
('Gospel'),
('Piano'),
('Solfège');

-- --------------------------------------------------------

--
-- Structure de la table `jour`
--

CREATE TABLE `jour` (
  `JOUR` char(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `jour`
--

INSERT INTO `jour` (`JOUR`) VALUES
('Dimanche'),
('Jeudi'),
('Lundi'),
('Mardi'),
('Mercredi'),
('Samedi'),
('Vendredi');

-- --------------------------------------------------------

--
-- Structure de la table `niveau`
--

CREATE TABLE `niveau` (
  `NIVEAU` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `niveau`
--

INSERT INTO `niveau` (`NIVEAU`) VALUES
(1),
(2),
(3),
(4);

-- --------------------------------------------------------

--
-- Structure de la table `payer`
--

CREATE TABLE `payer` (
  `IDELEVE` int(11) NOT NULL,
  `LIBELLE` char(32) NOT NULL,
  `DATEPAIEMENT` varchar(32) DEFAULT NULL,
  `PAYE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `payer`
--

INSERT INTO `payer` (`IDELEVE`, `LIBELLE`, `DATEPAIEMENT`, `PAYE`) VALUES
(1, 'Trimestre 1 · 2023', '01/01/2023', 600),
(2, 'Trimestre 1 · 2023', '15/01/2023', 600);

-- --------------------------------------------------------

--
-- Structure de la table `personne`
--

CREATE TABLE `personne` (
  `ID` int(11) NOT NULL,
  `NOM` char(32) DEFAULT NULL,
  `PRENOM` char(32) DEFAULT NULL,
  `TEL` text DEFAULT NULL,
  `MAIL` char(32) DEFAULT NULL,
  `ADRESSE` char(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `personne`
--

INSERT INTO `personne` (`ID`, `NOM`, `PRENOM`, `TEL`, `MAIL`, `ADRESSE`) VALUES
(1, 'TERPIN', 'Céleste', '07 65 44 32 12', 'celeste.terpin@efrei.net', '13 Allée des Cerisiers'),
(2, 'TREILLE', 'Lucas', 'TEST', 'lucas.treille@efrei.net', '2 Allée des Cerisiers'),
(3, 'BADREAU', 'Isabelle', 'isabelle.badreau@efrei.net', '07 77 21 34 56', '12 Avenue de la République'),
(4, 'HAMIDOU', 'Salim', '07 77 45 21 34', 'salim.hamidou@efrei.net', '2 Avenue de la République'),
(5, 'MEZAOUR', 'Billel', '06 78 76 55 43', 'billel.mezaour@efrei.net', '22 Avenue de la République'),
(6, 'LEONIDE', 'Jerry', '06 56 55 42 10', 'jerry.leonide@efrei.net', 'TEST'),
(7, 'BENMOUNA-JAYET', 'Mehdi', '06 79 87 54 33', 'mehdi.benmouna-jayet@efrei.net', '22 Allée des Cerisiers'),
(8, 'AISSAOUI', 'Yasmine', '0625144875', 'yasmine.aissaoui@efrei.net', '45 Allée des Cerisiers'),
(9, 'GERMAIN', 'Florian', '07 77 74 54 45', 'florian.germain@efrei.net', '45 Allée des Cerisiers'),
(10, 'CARTER', 'Beyoncé', 'TEST', 'beyonce.carter@efrei.net', 'TEST'),
(11, 'GOLDBERG', 'Whoopi', '06 54 45 33 22', 'whoopi.goldberg@efrei.net', 'TEST');

-- --------------------------------------------------------

--
-- Structure de la table `prof`
--

CREATE TABLE `prof` (
  `IDPROF` int(11) NOT NULL,
  `INSTRUMENT` char(32) NOT NULL,
  `SALAIRE` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `prof`
--

INSERT INTO `prof` (`IDPROF`, `INSTRUMENT`, `SALAIRE`) VALUES
(3, 'Piano', 3400),
(4, 'Solfège', 2000),
(6, 'Flute', 2000),
(11, 'Gospel', 4500);

-- --------------------------------------------------------

--
-- Structure de la table `seance`
--

CREATE TABLE `seance` (
  `IDPROF` int(11) NOT NULL,
  `NUMSEANCE` int(11) NOT NULL,
  `TRANCHE` char(32) NOT NULL,
  `JOUR` char(32) NOT NULL,
  `NIVEAU` int(11) NOT NULL,
  `CAPACITE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `seance`
--

INSERT INTO `seance` (`IDPROF`, `NUMSEANCE`, `TRANCHE`, `JOUR`, `NIVEAU`, `CAPACITE`) VALUES
(3, 6, '8h00-9h00', 'Lundi', 1, 10),
(3, 10, '10h00-11h00', 'Lundi', 4, 25),
(3, 15, '19h00-20h00', 'Lundi', 1, 10),
(3, 22, '19h00-20h00', 'Jeudi', 1, 10),
(4, 7, '8h00-10h00', 'Lundi', 4, 25),
(11, 11, '9h00-11h00', 'Dimanche', 2, 50),
(11, 14, '8h00-9h00', 'Dimanche', 4, 20),
(11, 17, '10h00-11h00', 'Jeudi', 1, 5),
(11, 23, '18h00-19h00', 'Jeudi', 3, 10),
(11, 28, '19h00-20h00', 'Mercredi', 4, 50);

-- --------------------------------------------------------

--
-- Structure de la table `trim`
--

CREATE TABLE `trim` (
  `LIBELLE` char(32) NOT NULL,
  `DATEFIN` char(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `trim`
--

INSERT INTO `trim` (`LIBELLE`, `DATEFIN`) VALUES
('Trimestre 1 · 2023', '31/03/2023'),
('Trimestre 2 · 2023', '30/06/2023'),
('Trimestre 3 · 2023', '30/09/2023'),
('Trimestre 4 · 2023', '31/12/2023');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `administrateur`
--
ALTER TABLE `administrateur`
  ADD PRIMARY KEY (`ID`);

--
-- Index pour la table `eleve`
--
ALTER TABLE `eleve`
  ADD PRIMARY KEY (`IDELEVE`);

--
-- Index pour la table `heure`
--
ALTER TABLE `heure`
  ADD PRIMARY KEY (`TRANCHE`);

--
-- Index pour la table `inscription`
--
ALTER TABLE `inscription`
  ADD PRIMARY KEY (`IDPROF`,`IDELEVE`,`NUMSEANCE`),
  ADD KEY `I_FK_INSCRIPTION_ELEVE` (`IDELEVE`),
  ADD KEY `I_FK_INSCRIPTION_SEANCE` (`IDPROF`,`NUMSEANCE`),
  ADD KEY `fk_numSeance` (`NUMSEANCE`);

--
-- Index pour la table `instrument`
--
ALTER TABLE `instrument`
  ADD PRIMARY KEY (`LIBELLE`);

--
-- Index pour la table `jour`
--
ALTER TABLE `jour`
  ADD PRIMARY KEY (`JOUR`);

--
-- Index pour la table `niveau`
--
ALTER TABLE `niveau`
  ADD PRIMARY KEY (`NIVEAU`),
  ADD KEY `NIVEAU` (`NIVEAU`);

--
-- Index pour la table `payer`
--
ALTER TABLE `payer`
  ADD PRIMARY KEY (`IDELEVE`,`LIBELLE`),
  ADD KEY `I_FK_PAYER_TRIM` (`LIBELLE`),
  ADD KEY `fk_paye_eleve` (`IDELEVE`),
  ADD KEY `I_FK_PAYER_INSCRIPTION` (`IDELEVE`);

--
-- Index pour la table `personne`
--
ALTER TABLE `personne`
  ADD PRIMARY KEY (`ID`);

--
-- Index pour la table `prof`
--
ALTER TABLE `prof`
  ADD PRIMARY KEY (`IDPROF`),
  ADD KEY `I_FK_PROF_INSTRUMENT` (`INSTRUMENT`);

--
-- Index pour la table `seance`
--
ALTER TABLE `seance`
  ADD PRIMARY KEY (`IDPROF`,`NUMSEANCE`),
  ADD KEY `I_FK_SEANCE_JOUR` (`JOUR`),
  ADD KEY `I_FK_SEANCE_NIVEAU` (`NIVEAU`),
  ADD KEY `I_FK_SEANCE_PROF` (`IDPROF`),
  ADD KEY `fk_tranche` (`TRANCHE`),
  ADD KEY `NUMSEANCE` (`NUMSEANCE`);

--
-- Index pour la table `trim`
--
ALTER TABLE `trim`
  ADD PRIMARY KEY (`LIBELLE`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `administrateur`
--
ALTER TABLE `administrateur`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `personne`
--
ALTER TABLE `personne`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT pour la table `seance`
--
ALTER TABLE `seance`
  MODIFY `NUMSEANCE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `eleve`
--
ALTER TABLE `eleve`
  ADD CONSTRAINT `fk_idEleve` FOREIGN KEY (`IDELEVE`) REFERENCES `personne` (`ID`);

--
-- Contraintes pour la table `inscription`
--
ALTER TABLE `inscription`
  ADD CONSTRAINT `fk_insc_eleve` FOREIGN KEY (`IDELEVE`) REFERENCES `eleve` (`IDELEVE`),
  ADD CONSTRAINT `fk_inscr_prof` FOREIGN KEY (`IDPROF`) REFERENCES `prof` (`IDPROF`),
  ADD CONSTRAINT `fk_numSeance` FOREIGN KEY (`NUMSEANCE`) REFERENCES `seance` (`NUMSEANCE`);

--
-- Contraintes pour la table `payer`
--
ALTER TABLE `payer`
  ADD CONSTRAINT `fk_paye_eleve` FOREIGN KEY (`IDELEVE`) REFERENCES `eleve` (`IDELEVE`),
  ADD CONSTRAINT `fk_paye_lib` FOREIGN KEY (`LIBELLE`) REFERENCES `trim` (`LIBELLE`);

--
-- Contraintes pour la table `prof`
--
ALTER TABLE `prof`
  ADD CONSTRAINT `fk_idProf` FOREIGN KEY (`IDPROF`) REFERENCES `personne` (`ID`),
  ADD CONSTRAINT `fk_refInstrument` FOREIGN KEY (`INSTRUMENT`) REFERENCES `instrument` (`LIBELLE`);

--
-- Contraintes pour la table `seance`
--
ALTER TABLE `seance`
  ADD CONSTRAINT `fk_jour` FOREIGN KEY (`JOUR`) REFERENCES `jour` (`JOUR`),
  ADD CONSTRAINT `fk_prof` FOREIGN KEY (`IDPROF`) REFERENCES `prof` (`IDPROF`),
  ADD CONSTRAINT `fk_tranche` FOREIGN KEY (`TRANCHE`) REFERENCES `heure` (`TRANCHE`),
  ADD CONSTRAINT `seance_ibfk_1` FOREIGN KEY (`NIVEAU`) REFERENCES `niveau` (`NIVEAU`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
