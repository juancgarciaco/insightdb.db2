-- CREATE DATABASE test;

DATABASE test;

DROP TABLE IF EXISTS informix.adm_globalparams_vertical;

CREATE TABLE adm_globalparams_vertical (
    agpv_id SERIAL NOT NULL,
    agpv_paramname VARCHAR(60) NOT NULL,
    agpv_paramvalue VARCHAR(100) NOT NULL,
    agpv_description VARCHAR(200),
    agpv_rowstate CHAR(1) DEFAULT 'A' NOT NULL,
    agpv_deleted BOOLEAN DEFAULT 'f' NOT NULL,
    agpv_createddate DATETIME YEAR TO FRACTION DEFAULT CURRENT YEAR TO FRACTION NOT NULL,
    agpv_createduser VARCHAR(32) NOT NULL
)
LOCK MODE ROW
;

CREATE UNIQUE INDEX informix.adm_globalparams_vertical_uixnombreparametro on informix.adm_globalparams_vertical ( agpv_paramname );

CREATE INDEX informix.adm_globalparams_vertical_ixestado on informix.adm_globalparams_vertical ( agpv_rowstate );

CREATE INDEX informix.adm_globalparams_vertical_ixfechacreacion on informix.adm_globalparams_vertical ( agpv_createddate );

ALTER TABLE informix.adm_globalparams_vertical ADD CONSTRAINT PRIMARY KEY (agpv_id) CONSTRAINT informix.adm_globalparams_vertical_pk;


INSERT INTO adm_globalparams_vertical
( agpv_id, agpv_paramname, agpv_paramvalue, agpv_description, agpv_createduser )
SELECT * FROM (
	SELECT 0, "MOD1_VAR1_INT", "120", "INT VARIABLE TO USE AT MODULE 1", "userloggedin" UNION
	SELECT 0, "MOD1_VAR2_DEC", "0.98", "DEC VARIABLE TO USE AT MODULE 1", "userloggedin" UNION
	SELECT 0, "MOD1_VAR3_STRING", "MY NAME", "STRING VARIABLE TO USE AT MODULE 1", "userloggedin" UNION
	SELECT 0, "MOD2_VAR1_BOOL", "true", "BOOL VARIABLE TO USE AT MODULE 2", "userloggedin"
)
;

-- SELECT * FROM adm_globalparams_vertical;
UPDATE adm_globalparams_vertical
SET agpv_deleted = 't'
WHERE agpv_paramname == 'MOD1_VAR3_STRING'
;
-- SELECT * FROM adm_globalparams_vertical WHERE agpv_deleted == 'f';
------------------------------------------
DROP VIEW IF EXISTS informix.v_adm_globalparams_vertical;

CREATE VIEW informix.v_adm_globalparams_vertical
AS 
SELECT
	agpv_id, agpv_paramname, agpv_paramvalue, agpv_description, agpv_rowstate
FROM
	adm_globalparams_vertical
WHERE
	agpv_deleted == 'f'
;

GRANT SELECT ON v_adm_globalparams_vertical TO public;

SELECT * FROM v_adm_globalparams_vertical;

------------------------------------------
DROP PROCEDURE IF EXISTS informix.proc_globalparams_vertical_byname;

CREATE PROCEDURE informix.proc_globalparams_vertical_byname(
	p_paramname1 VARCHAR(60)
)
	RETURNING
		  INTEGER agpv_id
		, VARCHAR(60) agpv_paramname
		, VARCHAR(100) agpv_paramvalue
		, VARCHAR(200) agpv_description
	;

	-- DEFINES
	DEFINE t_paramname1 VARCHAR(60);
	-- OUT VARS
	DEFINE v_paramname VARCHAR(60);
    DEFINE v_paramvalue VARCHAR(100);
    DEFINE v_description VARCHAR(200);
    DEFINE v_rowstate CHAR(1);

	-- ASSIGNS
	LET t_paramname1 = UPPER(p_paramname1);

	FOREACH
		SELECT
			agpv_id, agpv_paramname, agpv_paramvalue, agpv_description, agpv_rowstate
		INTO
			v_id, v_paramname, v_paramvalue, v_description, v_rowstate
		FROM 
			v_adm_globalparams_vertical
		WHERE
			UPPER(agpv_paramname) == t_paramname1
			
		RETURN 
			v_id, v_paramname, v_paramvalue, v_description, v_rowstate
		WITH RESUME;
	END FOREACH;

END PROCEDURE;

GRANT EXECUTE ON PROCEDURE proc_globalparams_vertical_byname TO PUBLIC;

