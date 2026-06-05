SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

CREATE DATABASE IF NOT EXISTS `domestikaerolineadb` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `domestikaerolineadb`;

CREATE TABLE `destinos` (
  `id_destino` int(11) NOT NULL,
  `nombre_destino` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO `destinos` (`id_destino`, `nombre_destino`) VALUES
(1, 'Antofagasta'),
(2, 'Punta Arenas'),
(3, 'Santiago');

CREATE TABLE `pasajero` (
  `rut` varchar(10) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `apellido` varchar(100) NOT NULL,
  `id_tipo_pasajero` int(11) NOT NULL,
  `puntaje` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO `pasajero` (`rut`, `nombre`, `apellido`, `id_tipo_pasajero`, `puntaje`) VALUES
('11111111-1', 'Carla', 'Castillo', 2, 1000),
('22222222-2', 'Lorena', 'Tapia', 1, 1000);

CREATE TABLE `reserva` (
  `codigo` varchar(10) NOT NULL,
  `rut` varchar(10) NOT NULL,
  `numvlo` varchar(10) NOT NULL,
  `id_tipo_reserva` int(11) NOT NULL,
  `valor` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO `reserva` (`codigo`, `rut`, `numvlo`, `id_tipo_reserva`, `valor`) VALUES
('RES-0004', '11111111-1', 'DMK-002', 3, 70000),
('RES-002', '22222222-2', 'DMK-001', 1, 35500),
('RES-003', '22222222-2', 'DMK-002', 1, 35500);

CREATE TABLE `tipo_pasajero` (
  `id_tipo` int(11) NOT NULL,
  `nombre_tipo` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO `tipo_pasajero` (`id_tipo`, `nombre_tipo`) VALUES
(2, 'Frecuente'),
(1, 'Normal');

CREATE TABLE `tipo_reserva` (
  `id_tipo` int(11) NOT NULL,
  `nombre_tipo` varchar(50) NOT NULL,
  `condicion_mensaje` varchar(100) NOT NULL,
  `recargo_porcentaje` decimal(5,2) NOT NULL,
  `valor_base` double DEFAULT 0,
  `gasto_embarque` double DEFAULT 0,
  `puntaje` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO `tipo_reserva` (`id_tipo`, `nombre_tipo`, `condicion_mensaje`, `recargo_porcentaje`, `valor_base`, `gasto_embarque`, `puntaje`) VALUES
(1, 'Económica', 'No sujeta a cambio', 0.00, 30000, 5500, 500),
(2, 'Turista', 'Para cambio debe pagar 10% del valor base', 0.10, 40000, 6000, 700),
(3, 'Ejecutiva', 'Puede efectuar cambio sin costo', 0.00, 60000, 10000, 1000);

CREATE TABLE `usuario` (
  `id_usuario` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password_hash` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO `usuario` (`id_usuario`, `username`, `password_hash`) VALUES
(1, 'admin', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4');

CREATE TABLE `vuelo` (
  `numvlo` varchar(10) NOT NULL,
  `fecha` varchar(10) NOT NULL,
  `hora` varchar(5) NOT NULL,
  `id_destino` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO `vuelo` (`numvlo`, `fecha`, `hora`, `id_destino`) VALUES
('DMK-001', '29-05-2026', '13:20', 1),
('DMK-002', '08-06-2026', '10:30', 2),
('DMK-004', '11-06-2026', '18:00', 3);


ALTER TABLE `destinos`
  ADD PRIMARY KEY (`id_destino`),
  ADD UNIQUE KEY `nombre_destino` (`nombre_destino`);

ALTER TABLE `pasajero`
  ADD PRIMARY KEY (`rut`),
  ADD KEY `fk_pasajero_tipo` (`id_tipo_pasajero`);

ALTER TABLE `reserva`
  ADD PRIMARY KEY (`codigo`),
  ADD KEY `fk_reserva_tipo` (`id_tipo_reserva`),
  ADD KEY `fk_reserva_vuelo` (`numvlo`),
  ADD KEY `fk_reserva_pasajero` (`rut`);

ALTER TABLE `tipo_pasajero`
  ADD PRIMARY KEY (`id_tipo`),
  ADD UNIQUE KEY `nombre_tipo` (`nombre_tipo`);

ALTER TABLE `tipo_reserva`
  ADD PRIMARY KEY (`id_tipo`),
  ADD UNIQUE KEY `nombre_tipo` (`nombre_tipo`);

ALTER TABLE `usuario`
  ADD PRIMARY KEY (`id_usuario`),
  ADD UNIQUE KEY `username` (`username`);

ALTER TABLE `vuelo`
  ADD PRIMARY KEY (`numvlo`),
  ADD KEY `fk_vuelo_destinos` (`id_destino`);


ALTER TABLE `destinos`
  MODIFY `id_destino` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

ALTER TABLE `tipo_pasajero`
  MODIFY `id_tipo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

ALTER TABLE `tipo_reserva`
  MODIFY `id_tipo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

ALTER TABLE `usuario`
  MODIFY `id_usuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;


ALTER TABLE `pasajero`
  ADD CONSTRAINT `fk_pasajero_tipo` FOREIGN KEY (`id_tipo_pasajero`) REFERENCES `tipo_pasajero` (`id_tipo`);

ALTER TABLE `reserva`
  ADD CONSTRAINT `fk_reserva_pasajero` FOREIGN KEY (`rut`) REFERENCES `pasajero` (`rut`),
  ADD CONSTRAINT `fk_reserva_tipo` FOREIGN KEY (`id_tipo_reserva`) REFERENCES `tipo_reserva` (`id_tipo`),
  ADD CONSTRAINT `fk_reserva_vuelo` FOREIGN KEY (`numvlo`) REFERENCES `vuelo` (`numvlo`);

ALTER TABLE `vuelo`
  ADD CONSTRAINT `fk_vuelo_destinos` FOREIGN KEY (`id_destino`) REFERENCES `destinos` (`id_destino`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
