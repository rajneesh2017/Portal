﻿DROP TABLE IF EXISTS dbo.blogs;

CREATE TABLE blogs (
blogID VARCHAR(20) PRIMARY KEY, 
title VARCHAR(100),
body VARCHAR(3000) ,
email VARCHAR(50)
); 