# insightdb.db2
insightdb.db2

Basic sample using insight.Database With IDS through DB2 Driver
Must Install only IBM Data Server Driver Package

Tools
	Visual studio 2017
	.Net FrameWork 4.72
	IBM DSDP 10.5
	IBM Informix 14.10 (local by docker)
	Insight.Database 5.2.10


Basic rest api bootstrap
	Based on a DB VIEW
		GetAll ==> http://localhost:47542/api/basic
		GetById ==> http://localhost:47542/api/basic/2

Personalized rest api bootstrap
	Based on a DB VIEW
		GetAll ==> http://localhost:47542/v1/GlobalParams/getAllParams 
		GetById ==> http://localhost:47542/v1/globalparams/getparambyid/1
		GetByName ==> http://localhost:47542/v1/globalparams/getparambyname/mod1_var2_dec
	Based on a DB PROC
		GetBayNamme2 ==> http://localhost:47542/v1/globalparams/getparambyname2/mod1_var2_dec