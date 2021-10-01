CREATE TABLE territories(
territoryid string,
territoryname string,
regionid int)
ROW FORMAT DELIMITED FIELDS TERMINATED BY '\t';

LOAD DATA LOCAL INPATH '/class/datasets/northwind/TSV/territories' OVERWRITE INTO TABLE territories;

select * from territories;


