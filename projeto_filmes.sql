-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 28, 2025 at 01:06 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `projeto_filmes`
--
CREATE DATABASE IF NOT EXISTS `projeto_filmes` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `projeto_filmes`;

-- --------------------------------------------------------

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
CREATE TABLE IF NOT EXISTS `clientes` (
  `idCliente` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `cpf` varchar(45) NOT NULL,
  `telefone` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `endereco` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idCliente`),
  UNIQUE KEY `cpf` (`cpf`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `clientes`
--

INSERT INTO `clientes` (`idCliente`, `nome`, `cpf`, `telefone`, `email`, `endereco`) VALUES
(1, 'Ana Costa', '123.456.789-00', '(11) 98888-7777', 'ana.costa@cliente.com', 'Rua das Flores, 123, São Paulo - SP'),
(2, 'Pedro Almeida', '234.567.890-11', '(11) 97777-6666', 'pedro.almeida@cliente.com', 'Avenida Paulista, 2000, São Paulo - SP'),
(3, 'Juliana Pereira', '345.678.901-22', '(21) 96666-5555', 'juliana.pereira@cliente.com', 'Rua da Liberdade, 456, Rio de Janeiro - RJ'),
(4, 'Rafael Santos', '456.789.012-33', '(31) 95555-4444', 'rafael.santos@cliente.com', 'Rua Sete de Setembro, 789, Belo Horizonte - M'),
(5, 'Carla Oliveira', '567.890.123-44', '(41) 94444-3333', 'carla.oliveira@cliente.com', 'Praça Tiradentes, 1010, Curitiba - PR'),
(9, 'laura', '000,000,000-00', '(00) 0000-0000', 'aaaaaaaaaaa', 'bbbbbbbbbbb');

--
-- Triggers `clientes`
--
DROP TRIGGER IF EXISTS `trg_clientes_after_delete`;
DELIMITER $$
CREATE TRIGGER `trg_clientes_after_delete` AFTER DELETE ON `clientes` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Exclusão', NOW(), 'Clientes');
END
$$
DELIMITER ;
DROP TRIGGER IF EXISTS `trg_clientes_after_insert`;
DELIMITER $$
CREATE TRIGGER `trg_clientes_after_insert` AFTER INSERT ON `clientes` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Inserção', NOW(), 'Clientes');
END
$$
DELIMITER ;
DROP TRIGGER IF EXISTS `trg_clientes_after_update`;
DELIMITER $$
CREATE TRIGGER `trg_clientes_after_update` AFTER UPDATE ON `clientes` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Atualização', NOW(), 'Clientes');
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `filmes`
--

DROP TABLE IF EXISTS `filmes`;
CREATE TABLE IF NOT EXISTS `filmes` (
  `idFilme` int(11) NOT NULL AUTO_INCREMENT,
  `titulo` varchar(100) DEFAULT NULL,
  `genero` varchar(100) DEFAULT NULL,
  `duracao` int(11) DEFAULT NULL,
  `ano_lancamento` int(11) DEFAULT NULL,
  `diretor` varchar(100) DEFAULT NULL,
  `disponivel` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idFilme`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `filmes`
--

INSERT INTO `filmes` (`idFilme`, `titulo`, `genero`, `duracao`, `ano_lancamento`, `diretor`, `disponivel`) VALUES
(1, 'Exterminador do Futuro', 'ação', 108, 1984, 'James Cameron', 1),
(2, 'Matrix', 'ação', 136, 1999, 'Lana Wachowski & Lilly Wachowski', 1),
(3, 'Superbad', 'comédia', 113, 2007, 'Greg Mottola', 1),
(4, 'Curtindo a Vida Adoidado', 'comédia', 103, 1986, 'John Hughes', 1),
(5, 'Oppenheimer', 'drama', 181, 2023, 'Christopher Nolan', 1),
(6, 'Cisne Negro', 'drama', 109, 2010, 'Darren Aronofsky', 1),
(7, 'Blade Runner', 'ficção científica', 118, 1982, 'Ridley Scott', 1),
(8, 'Alien', 'ficção científica', 117, 1979, 'Ridley Scott', 1),
(9, 'Psicose', 'terror', 109, 1960, 'Alfred Hitchcock', 1),
(10, 'O Silêncio dos Inocentes', 'terror', 119, 1991, 'Jonhathan Demme', 1),
(11, 'Casablanca', 'romance', 103, 1942, 'Michael Curtiz', 1),
(12, 'Brilho Eterno de uma Mente sem Lembranças', 'romance', 108, 2004, 'Michel Gondry', 1),
(13, 'Persépolis', 'animação', 95, 2007, 'Vincent Paronnaud & Marjane Satrapi', 1),
(14, 'A Viagem de Chihiro', 'animação', 125, 2001, 'Hayao Miyazaki', 1),
(15, 'Navalny', 'documentário', 98, 2022, 'Daniel Roher', 1),
(16, 'Pare de Fazer Sentido', 'documentário', 88, 1984, 'Jonathan Demme', 1),
(17, 'Drácula de Bram Stoker', 'terror', 128, 1992, 'Francis Ford Coppola', 0),
(18, 'O Samurai', 'drama', 105, 1967, 'Jean-Pierre Melville', 0),
(19, 'Kill Bill: Vol. 1', 'ação', 111, 2003, 'Quentin Tarantino', 0);

--
-- Triggers `filmes`
--
DROP TRIGGER IF EXISTS `trg_filmes_after_delete`;
DELIMITER $$
CREATE TRIGGER `trg_filmes_after_delete` AFTER DELETE ON `filmes` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Exclusão', NOW(), 'Filmes');
END
$$
DELIMITER ;
DROP TRIGGER IF EXISTS `trg_filmes_after_insert`;
DELIMITER $$
CREATE TRIGGER `trg_filmes_after_insert` AFTER INSERT ON `filmes` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Inserção', NOW(), 'Filmes');
END
$$
DELIMITER ;
DROP TRIGGER IF EXISTS `trg_filmes_after_update`;
DELIMITER $$
CREATE TRIGGER `trg_filmes_after_update` AFTER UPDATE ON `filmes` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Atualização', NOW(), 'Filmes');
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `funcionarios`
--

DROP TABLE IF EXISTS `funcionarios`;
CREATE TABLE IF NOT EXISTS `funcionarios` (
  `idFuncionario` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `cpf` varchar(45) NOT NULL,
  `telefone` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `cargo` varchar(45) DEFAULT NULL,
  `idUsuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`idFuncionario`),
  UNIQUE KEY `cpf` (`cpf`),
  KEY `idUsuario` (`idUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `funcionarios`
--

INSERT INTO `funcionarios` (`idFuncionario`, `nome`, `cpf`, `telefone`, `email`, `cargo`, `idUsuario`) VALUES
(1, 'João Silva', '123.456.789-00', '(11) 98765-4321', 'joao.silva@locadora.com', 'Gerente', 1),
(2, 'Maria Oliveira', '234.567.890-11', '(11) 91234-5678', 'maria.oliveira@locadora.com', 'Atendente', 2),
(3, 'Carlos Souza', '345.678.901-22', '(11) 92345-6789', 'carlos.souza@locadora.com', 'Atendente', 3),
(4, 'Fernanda Lima', '456.789.012-33', '(11) 93456-7890', 'fernanda.lima@locadora.com', 'Assistente Administrativo', 4),
(5, 'Roberto Santos', '567.890.123-44', '(11) 94567-8901', 'roberto.santos@locadora.com', 'Caixa', 5);

--
-- Triggers `funcionarios`
--
DROP TRIGGER IF EXISTS `trg_funcionarios_after_delete`;
DELIMITER $$
CREATE TRIGGER `trg_funcionarios_after_delete` AFTER DELETE ON `funcionarios` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Exclusão', NOW(), 'Funcionarios');
END
$$
DELIMITER ;
DROP TRIGGER IF EXISTS `trg_funcionarios_after_insert`;
DELIMITER $$
CREATE TRIGGER `trg_funcionarios_after_insert` AFTER INSERT ON `funcionarios` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Inserção', NOW(), 'Funcionarios');
END
$$
DELIMITER ;
DROP TRIGGER IF EXISTS `trg_funcionarios_after_update`;
DELIMITER $$
CREATE TRIGGER `trg_funcionarios_after_update` AFTER UPDATE ON `funcionarios` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Atualização', NOW(), 'Funcionarios');
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `itens_locacao`
--

DROP TABLE IF EXISTS `itens_locacao`;
CREATE TABLE IF NOT EXISTS `itens_locacao` (
  `idItem` int(11) NOT NULL AUTO_INCREMENT,
  `idLocacao` int(11) DEFAULT NULL,
  `idFilme` int(11) DEFAULT NULL,
  `valor` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`idItem`),
  KEY `idLocacao` (`idLocacao`),
  KEY `idFilme` (`idFilme`)
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `itens_locacao`
--

INSERT INTO `itens_locacao` (`idItem`, `idLocacao`, `idFilme`, `valor`) VALUES
(1, 1, 1, 10.00),
(2, 1, 3, 12.50),
(3, 2, 2, 15.00),
(4, 2, 4, 8.00),
(5, 3, 5, 20.00),
(6, 3, 6, 18.00),
(7, 4, 7, 14.00),
(8, 4, 8, 13.50),
(9, 5, 9, 9.00),
(10, 5, 10, 11.00),
(44, 5, 11, 8.50),
(45, 5, 12, 9.00),
(46, 5, 13, 7.50),
(47, 5, 14, 10.00),
(48, 5, 15, 9.50),
(49, 5, 16, 8.00),
(50, 5, 17, 11.00),
(51, 5, 18, 10.50),
(52, 5, 19, 12.00);

--
-- Triggers `itens_locacao`
--
DROP TRIGGER IF EXISTS `trg_itens_locacao_after_delete`;
DELIMITER $$
CREATE TRIGGER `trg_itens_locacao_after_delete` AFTER DELETE ON `itens_locacao` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Exclusão', NOW(), 'Itens_Locacao');
END
$$
DELIMITER ;
DROP TRIGGER IF EXISTS `trg_itens_locacao_after_insert`;
DELIMITER $$
CREATE TRIGGER `trg_itens_locacao_after_insert` AFTER INSERT ON `itens_locacao` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Inserção', NOW(), 'Itens_Locacao');
END
$$
DELIMITER ;
DROP TRIGGER IF EXISTS `trg_itens_locacao_after_update`;
DELIMITER $$
CREATE TRIGGER `trg_itens_locacao_after_update` AFTER UPDATE ON `itens_locacao` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Atualização', NOW(), 'Itens_Locacao');
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `locacoes`
--

DROP TABLE IF EXISTS `locacoes`;
CREATE TABLE IF NOT EXISTS `locacoes` (
  `idLocacao` int(11) NOT NULL AUTO_INCREMENT,
  `idCliente` int(11) DEFAULT NULL,
  `data_locacao` date DEFAULT NULL,
  `data_devolucao` date DEFAULT NULL,
  `data_real` date DEFAULT NULL,
  PRIMARY KEY (`idLocacao`),
  KEY `idCliente` (`idCliente`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `locacoes`
--

INSERT INTO `locacoes` (`idLocacao`, `idCliente`, `data_locacao`, `data_devolucao`, `data_real`) VALUES
(1, 1, '2025-05-01', '2025-05-08', '2025-05-06'),
(2, 2, '2025-05-02', '2025-05-09', NULL),
(3, 3, '2025-05-03', '2025-05-10', '2025-05-09'),
(4, 4, '2025-05-04', '2025-05-11', NULL),
(5, 5, '2025-05-05', '2025-05-12', '2025-05-12');

--
-- Triggers `locacoes`
--
DROP TRIGGER IF EXISTS `trg_locacoes_after_delete`;
DELIMITER $$
CREATE TRIGGER `trg_locacoes_after_delete` AFTER DELETE ON `locacoes` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Exclusão', NOW(), 'Locacoes');
END
$$
DELIMITER ;
DROP TRIGGER IF EXISTS `trg_locacoes_after_insert`;
DELIMITER $$
CREATE TRIGGER `trg_locacoes_after_insert` AFTER INSERT ON `locacoes` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Inserção', NOW(), 'Locacoes');
END
$$
DELIMITER ;
DROP TRIGGER IF EXISTS `trg_locacoes_after_update`;
DELIMITER $$
CREATE TRIGGER `trg_locacoes_after_update` AFTER UPDATE ON `locacoes` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Atualização', NOW(), 'Locacoes');
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `logs`
--

DROP TABLE IF EXISTS `logs`;
CREATE TABLE IF NOT EXISTS `logs` (
  `idLogs` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(45) DEFAULT NULL,
  `acao` varchar(45) DEFAULT NULL,
  `data_hora` datetime DEFAULT NULL,
  `tabela_afetada` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idLogs`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `logs`
--

INSERT INTO `logs` (`idLogs`, `usuario`, `acao`, `data_hora`, `tabela_afetada`) VALUES
(2, 'sistema', 'Exclusão', '2025-05-25 19:52:05', 'Clientes'),
(3, NULL, 'Inserção', '2025-05-27 15:48:14', 'Usuarios'),
(4, NULL, 'Exclusão', '2025-05-27 15:48:18', 'Usuarios'),
(5, NULL, 'Inserção', '2025-05-27 16:36:21', 'Usuarios'),
(6, NULL, 'Exclusão', '2025-05-27 16:36:26', 'Usuarios'),
(7, NULL, 'Inserção', '2025-05-27 17:02:23', 'Usuarios'),
(8, NULL, 'Exclusão', '2025-05-27 17:02:27', 'Usuarios'),
(9, NULL, 'Inserção', '2025-05-27 17:05:01', 'Usuarios'),
(10, NULL, 'Exclusão', '2025-05-27 17:05:04', 'Usuarios'),
(11, 'admin (admin)', 'Exclusão', '2025-05-27 19:00:53', 'Filmes'),
(12, 'admin (admin)', 'Exclusão', '2025-05-27 19:00:58', 'Filmes'),
(13, 'admin (admin)', 'Exclusão', '2025-05-27 19:01:04', 'Filmes'),
(14, 'admin (admin)', 'Inserção', '2025-05-27 19:06:16', 'Clientes'),
(15, NULL, 'Inserção', '2025-05-27 19:06:23', 'Usuarios'),
(16, NULL, 'Exclusão', '2025-05-27 19:11:38', 'Usuarios'),
(17, 'admin (admin)', 'Exclusão', '2025-05-27 19:11:44', 'Clientes'),
(18, 'teste3 (cliente)', 'Inserção', '2025-05-27 19:12:13', 'Clientes'),
(19, NULL, 'Inserção', '2025-05-27 19:12:23', 'Usuarios'),
(20, 'admin (admin)', 'Exclusão', '2025-05-27 19:13:23', 'Clientes'),
(21, NULL, 'Exclusão', '2025-05-27 19:13:29', 'Usuarios'),
(22, 'laura (cliente)', 'Inserção', '2025-05-27 19:14:28', 'Locacoes'),
(23, 'laura (cliente)', 'Inserção', '2025-05-27 19:14:28', 'Itens_Locacao'),
(24, 'laura (cliente)', 'Atualização', '2025-05-27 19:14:28', 'Filmes'),
(25, 'laura (cliente)', 'Atualização', '2025-05-27 19:14:28', 'Filmes'),
(26, 'admin (admin)', 'Exclusão', '2025-05-27 19:15:14', 'Itens_Locacao'),
(27, 'admin (admin)', 'Exclusão', '2025-05-27 19:15:14', 'Locacoes'),
(28, 'admin (admin)', 'Atualização', '2025-05-27 19:15:28', 'Filmes'),
(29, 'admin (admin)', 'Atualização', '2025-05-27 19:15:28', 'Filmes'),
(30, NULL, 'Inserção', '2025-05-27 19:15:40', 'Usuarios'),
(31, NULL, 'Exclusão', '2025-05-27 19:15:43', 'Usuarios'),
(32, 'teste (cliente)', 'Inserção', '2025-05-27 19:19:04', 'Usuarios'),
(33, 'teste (cliente)', 'Exclusão', '2025-05-27 19:19:08', 'Usuarios'),
(34, 'admin (admin)', 'Inserção', '2025-05-27 19:22:23', 'Usuarios'),
(35, 'admin (admin)', 'Exclusão', '2025-05-27 19:22:27', 'Usuarios'),
(36, 'teste (cliente)', 'Inserção', '2025-05-27 19:23:11', 'Usuarios'),
(37, 'teste (cliente)', 'Inserção', '2025-05-27 19:25:11', 'Clientes'),
(38, 'admin (admin)', 'Exclusão', '2025-05-27 19:25:36', 'Clientes'),
(39, 'admin (admin)', 'Exclusão', '2025-05-27 19:25:42', 'Usuarios');

-- --------------------------------------------------------

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE IF NOT EXISTS `usuarios` (
  `idUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `nome_usuario` varchar(45) NOT NULL,
  `senha` varchar(255) NOT NULL,
  `nivel_acesso` varchar(45) DEFAULT NULL,
  `idCliente` int(11) DEFAULT NULL,
  PRIMARY KEY (`idUsuario`),
  UNIQUE KEY `nome_usuario` (`nome_usuario`),
  KEY `fk_usuario_cliente` (`idCliente`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `usuarios`
--

INSERT INTO `usuarios` (`idUsuario`, `nome_usuario`, `senha`, `nivel_acesso`, `idCliente`) VALUES
(1, 'admin', 'admin', 'admin', NULL),
(2, 'ana', 'senha_ana', 'cliente', 1),
(3, 'pedro', 'senha_pedro', 'cliente', 2),
(4, 'juliana', 'senha_juliana', 'cliente', 3),
(5, 'rafael', 'senha_rafael', 'cliente', 4),
(6, 'carla', 'senha_carla', 'cliente', 5),
(19, 'laura', 'teste', 'cliente', 9);

--
-- Triggers `usuarios`
--
DROP TRIGGER IF EXISTS `trg_usuarios_after_delete`;
DELIMITER $$
CREATE TRIGGER `trg_usuarios_after_delete` AFTER DELETE ON `usuarios` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Exclusão', NOW(), 'Usuarios');
END
$$
DELIMITER ;
DROP TRIGGER IF EXISTS `trg_usuarios_after_insert`;
DELIMITER $$
CREATE TRIGGER `trg_usuarios_after_insert` AFTER INSERT ON `usuarios` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Inserção', NOW(), 'Usuarios');
END
$$
DELIMITER ;
DROP TRIGGER IF EXISTS `trg_usuarios_after_update`;
DELIMITER $$
CREATE TRIGGER `trg_usuarios_after_update` AFTER UPDATE ON `usuarios` FOR EACH ROW BEGIN
    DECLARE v_usuario VARCHAR(100);
    DECLARE v_tipo VARCHAR(50);

    SELECT usuario, tipo_usuario INTO v_usuario, v_tipo FROM UsuarioSessao WHERE id = 1;

    INSERT INTO Logs (usuario, acao, data_hora, tabela_afetada)
    VALUES (CONCAT(v_usuario, ' (', v_tipo, ')'), 'Atualização', NOW(), 'Usuarios');
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `usuariosessao`
--

DROP TABLE IF EXISTS `usuariosessao`;
CREATE TABLE IF NOT EXISTS `usuariosessao` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(100) DEFAULT NULL,
  `tipo_usuario` varchar(50) DEFAULT NULL,
  `data_hora` datetime DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `usuariosessao`
--

INSERT INTO `usuariosessao` (`id`, `usuario`, `tipo_usuario`, `data_hora`) VALUES
(1, 'admin', 'admin', '2025-05-27 19:26:56');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `funcionarios`
--
ALTER TABLE `funcionarios`
  ADD CONSTRAINT `funcionarios_ibfk_1` FOREIGN KEY (`idUsuario`) REFERENCES `usuarios` (`idUsuario`);

--
-- Constraints for table `itens_locacao`
--
ALTER TABLE `itens_locacao`
  ADD CONSTRAINT `itens_locacao_ibfk_1` FOREIGN KEY (`idLocacao`) REFERENCES `locacoes` (`idLocacao`),
  ADD CONSTRAINT `itens_locacao_ibfk_2` FOREIGN KEY (`idFilme`) REFERENCES `filmes` (`idFilme`);

--
-- Constraints for table `locacoes`
--
ALTER TABLE `locacoes`
  ADD CONSTRAINT `locacoes_ibfk_1` FOREIGN KEY (`idCliente`) REFERENCES `clientes` (`idCliente`);

--
-- Constraints for table `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `fk_usuario_cliente` FOREIGN KEY (`idCliente`) REFERENCES `clientes` (`idCliente`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
