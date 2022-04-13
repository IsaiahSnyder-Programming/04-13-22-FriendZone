CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
--
--
SELECT
  *
FROM
  accounts;
--
  --
INSERT INTO
  accounts (id, name, email, picture)
VALUES
  (
    'testId1',
    'testAccount',
    'testAccount@test.com',
    'https://s.gravatar.com/avatar/a595cb510e98017d670addad17a9fdd2?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fca.png'
  );
SELECT
  LAST_INSERT_ID();
--
  --
  CREATE TABLE IF NOT EXISTS follows(
    id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    followerId VARCHAR(255) NOT NULL,
    followingId VARCHAR(255) NOT NULL,
    FOREIGN KEY (followerId) REFERENCES accounts(id) ON DELETE CASCADE,
    FOREIGN KEY (followingId) REFERENCES accounts(id) ON DELETE CASCADE
  ) default charset utf8 COMMENT '';
--
  --
  DROP TABLE IF EXISTS follows;
--
  --
SELECT
  *
FROM
  follows;