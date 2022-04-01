--
-- PostgreSQL database dump
--

-- Dumped from database version 10.19
-- Dumped by pg_dump version 10.19

-- Started on 2022-04-01 08:58:59

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 200 (class 1259 OID 60131)
-- Name: cdmtimer; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.cdmtimer (
    id bigint NOT NULL,
    name character varying(250),
    chunkid integer,
    query text,
    starttime timestamp without time zone,
    endtime timestamp without time zone,
    workloadid bigint NOT NULL,
    status integer,
    errorlog text
);


--
-- TOC entry 2930 (class 0 OID 0)
-- Dependencies: 200
-- Name: COLUMN cdmtimer.chunkid; Type: COMMENT; Schema: public; Owner: -
--

COMMENT ON COLUMN public.cdmtimer.chunkid IS '-1';


--
-- TOC entry 202 (class 1259 OID 60144)
-- Name: chunktimer; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.chunktimer (
    id bigint NOT NULL,
    chunkid bigint,
    starttime timestamp without time zone,
    endtime timestamp without time zone,
    touched boolean DEFAULT false,
    workloadid integer,
    status integer,
    errorlog text
);


--
-- TOC entry 215 (class 1259 OID 62158)
-- Name: active_queries; Type: VIEW; Schema: public; Owner: -
--

CREATE VIEW public.active_queries AS
 SELECT c.chunkid,
    c.starttime AS chunk_start,
    c2.name,
    c2.query,
    c2.starttime,
    c2.status
   FROM (public.chunktimer c
     JOIN public.cdmtimer c2 ON (((c2.chunkid = c.chunkid) AND (c.workloadid = c2.workloadid))))
  WHERE ((c.starttime IS NOT NULL) AND (c.touched = true) AND (c2.status <> ALL (ARRAY[6, 8])));


--
-- TOC entry 199 (class 1259 OID 60129)
-- Name: cdmtimer_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.cdmtimer_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 2931 (class 0 OID 0)
-- Dependencies: 199
-- Name: cdmtimer_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.cdmtimer_id_seq OWNED BY public.cdmtimer.id;


--
-- TOC entry 201 (class 1259 OID 60142)
-- Name: chunktimer_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.chunktimer_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 2932 (class 0 OID 0)
-- Dependencies: 201
-- Name: chunktimer_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.chunktimer_id_seq OWNED BY public.chunktimer.id;


--
-- TOC entry 216 (class 1259 OID 62162)
-- Name: complete_queries; Type: VIEW; Schema: public; Owner: -
--

CREATE VIEW public.complete_queries AS
 SELECT c.chunkid,
    c.starttime AS chunk_start,
    c2.name,
    c2.starttime,
    c2.endtime,
    (c2.endtime - c2.starttime) AS duration,
    c2.status
   FROM (public.chunktimer c
     JOIN public.cdmtimer c2 ON (((c2.chunkid = c.chunkid) AND (c.workloadid = c2.workloadid))))
  WHERE ((c.starttime IS NOT NULL) AND (c2.status = 8));


--
-- TOC entry 217 (class 1259 OID 62166)
-- Name: completed_chunks; Type: VIEW; Schema: public; Owner: -
--

CREATE VIEW public.completed_chunks AS
 SELECT c.chunkid,
    c.starttime,
    c.endtime,
    c2.cdm_duration,
    (c.endtime - c.starttime) AS duration
   FROM (public.chunktimer c
     JOIN ( SELECT (max(cdmtimer.endtime) - min(cdmtimer.starttime)) AS cdm_duration,
            cdmtimer.chunkid,
            cdmtimer.workloadid
           FROM public.cdmtimer
          GROUP BY cdmtimer.workloadid, cdmtimer.chunkid) c2 ON (((c2.chunkid = c.chunkid) AND (c.workloadid = c2.workloadid))))
  WHERE ((c.starttime IS NOT NULL) AND (c.status = 8))
  ORDER BY c.chunkid;


--
-- TOC entry 210 (class 1259 OID 60192)
-- Name: dbschema; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.dbschema (
    id bigint NOT NULL,
    workloadid bigint NOT NULL,
    schematype character varying(250),
    server character varying(250),
    port integer,
    dbname character varying(250),
    schemaname character varying(250),
    username character varying(250),
    password character varying(250),
    testsuccess boolean DEFAULT false NOT NULL
);


--
-- TOC entry 209 (class 1259 OID 60190)
-- Name: dbschema_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.dbschema_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 2933 (class 0 OID 0)
-- Dependencies: 209
-- Name: dbschema_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.dbschema_id_seq OWNED BY public.dbschema.id;


--
-- TOC entry 204 (class 1259 OID 60157)
-- Name: queue; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.queue (
    id bigint NOT NULL,
    workqueueid integer,
    taskindex integer,
    parallelindex integer,
    filepath text,
    filecontent text,
    starttime timestamp without time zone,
    endtime timestamp without time zone,
    status integer,
    actiontype integer,
    ordinal integer,
    errorlog text,
    dbschemaid integer NOT NULL
);


--
-- TOC entry 203 (class 1259 OID 60155)
-- Name: queue_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.queue_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 2934 (class 0 OID 0)
-- Dependencies: 203
-- Name: queue_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.queue_id_seq OWNED BY public.queue.id;


--
-- TOC entry 206 (class 1259 OID 60168)
-- Name: servicestatus; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.servicestatus (
    id bigint NOT NULL,
    servicename character varying(250),
    servicedescription character varying(450),
    status integer,
    lastrun timestamp without time zone
);


--
-- TOC entry 205 (class 1259 OID 60166)
-- Name: servicestatus_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.servicestatus_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 2935 (class 0 OID 0)
-- Dependencies: 205
-- Name: servicestatus_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.servicestatus_id_seq OWNED BY public.servicestatus.id;


--
-- TOC entry 208 (class 1259 OID 60179)
-- Name: sourcefile; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.sourcefile (
    id bigint NOT NULL,
    workloadid bigint NOT NULL,
    filename character varying(250) NOT NULL,
    filepath character varying(450) NOT NULL,
    filehash character varying(250),
    processed boolean DEFAULT false NOT NULL,
    tablename character varying(250) NOT NULL,
    code text NOT NULL,
    isfile boolean DEFAULT false NOT NULL
);


--
-- TOC entry 207 (class 1259 OID 60177)
-- Name: sourcefile_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.sourcefile_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 2936 (class 0 OID 0)
-- Dependencies: 207
-- Name: sourcefile_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.sourcefile_id_seq OWNED BY public.sourcefile.id;


--
-- TOC entry 198 (class 1259 OID 60115)
-- Name: work_load; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.work_load (
    id bigint NOT NULL,
    name character varying(250) NOT NULL,
    releasedate timestamp without time zone,
    fileslocked boolean DEFAULT false NOT NULL,
    sourceprocessed boolean DEFAULT false NOT NULL,
    cdmloaded boolean DEFAULT false NOT NULL,
    chunkssetup boolean DEFAULT false NOT NULL,
    chunksloaded boolean DEFAULT false NOT NULL,
    cdmprocessed boolean DEFAULT false NOT NULL,
    chunksize integer DEFAULT 500,
    isrunning boolean DEFAULT false NOT NULL,
    maxparallels integer DEFAULT 3 NOT NULL,
    testchunkcount integer,
    chunkstart integer DEFAULT 0,
    chunkend integer DEFAULT 0
);


--
-- TOC entry 212 (class 1259 OID 60209)
-- Name: work_queue; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.work_queue (
    id bigint NOT NULL,
    workloadid bigint NOT NULL,
    name character varying(250),
    queuetype integer,
    starttime timestamp without time zone,
    endtime timestamp without time zone,
    status integer,
    progresspercent integer,
    errorlog text
);


--
-- TOC entry 197 (class 1259 OID 60113)
-- Name: workload_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.workload_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 2937 (class 0 OID 0)
-- Dependencies: 197
-- Name: workload_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.workload_id_seq OWNED BY public.work_load.id;


--
-- TOC entry 211 (class 1259 OID 60207)
-- Name: workqueue_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.workqueue_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 2938 (class 0 OID 0)
-- Dependencies: 211
-- Name: workqueue_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.workqueue_id_seq OWNED BY public.work_queue.id;


--
-- TOC entry 2749 (class 2604 OID 60134)
-- Name: cdmtimer id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.cdmtimer ALTER COLUMN id SET DEFAULT nextval('public.cdmtimer_id_seq'::regclass);


--
-- TOC entry 2750 (class 2604 OID 60147)
-- Name: chunktimer id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.chunktimer ALTER COLUMN id SET DEFAULT nextval('public.chunktimer_id_seq'::regclass);


--
-- TOC entry 2757 (class 2604 OID 60195)
-- Name: dbschema id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.dbschema ALTER COLUMN id SET DEFAULT nextval('public.dbschema_id_seq'::regclass);


--
-- TOC entry 2752 (class 2604 OID 60160)
-- Name: queue id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.queue ALTER COLUMN id SET DEFAULT nextval('public.queue_id_seq'::regclass);


--
-- TOC entry 2753 (class 2604 OID 60171)
-- Name: servicestatus id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.servicestatus ALTER COLUMN id SET DEFAULT nextval('public.servicestatus_id_seq'::regclass);


--
-- TOC entry 2754 (class 2604 OID 60182)
-- Name: sourcefile id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.sourcefile ALTER COLUMN id SET DEFAULT nextval('public.sourcefile_id_seq'::regclass);


--
-- TOC entry 2737 (class 2604 OID 60118)
-- Name: work_load id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.work_load ALTER COLUMN id SET DEFAULT nextval('public.workload_id_seq'::regclass);


--
-- TOC entry 2759 (class 2604 OID 60212)
-- Name: work_queue id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.work_queue ALTER COLUMN id SET DEFAULT nextval('public.workqueue_id_seq'::regclass);

--
-- TOC entry 2939 (class 0 OID 0)
-- Dependencies: 199
-- Name: cdmtimer_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.cdmtimer_id_seq', 13346, true);


--
-- TOC entry 2940 (class 0 OID 0)
-- Dependencies: 201
-- Name: chunktimer_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.chunktimer_id_seq', 2182, true);


--
-- TOC entry 2941 (class 0 OID 0)
-- Dependencies: 209
-- Name: dbschema_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.dbschema_id_seq', 4, true);


--
-- TOC entry 2942 (class 0 OID 0)
-- Dependencies: 203
-- Name: queue_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.queue_id_seq', 1, false);


--
-- TOC entry 2943 (class 0 OID 0)
-- Dependencies: 205
-- Name: servicestatus_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.servicestatus_id_seq', 1, true);


--
-- TOC entry 2944 (class 0 OID 0)
-- Dependencies: 207
-- Name: sourcefile_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.sourcefile_id_seq', 1, false);


--
-- TOC entry 2945 (class 0 OID 0)
-- Dependencies: 197
-- Name: workload_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.workload_id_seq', 1, true);


--
-- TOC entry 2946 (class 0 OID 0)
-- Dependencies: 211
-- Name: workqueue_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.workqueue_id_seq', 189, true);


--
-- TOC entry 2763 (class 2606 OID 60140)
-- Name: cdmtimer cdmtimer_id_key; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.cdmtimer
    ADD CONSTRAINT cdmtimer_id_key UNIQUE (id);


--
-- TOC entry 2765 (class 2606 OID 60533)
-- Name: cdmtimer cdmtimer_unique; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.cdmtimer
    ADD CONSTRAINT cdmtimer_unique UNIQUE (name, workloadid, chunkid);


--
-- TOC entry 2767 (class 2606 OID 60153)
-- Name: chunktimer chunktimer_id_key; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.chunktimer
    ADD CONSTRAINT chunktimer_id_key UNIQUE (id);


--
-- TOC entry 2769 (class 2606 OID 62110)
-- Name: chunktimer chunktimer_unique; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.chunktimer
    ADD CONSTRAINT chunktimer_unique UNIQUE (chunkid, workloadid);


--
-- TOC entry 2777 (class 2606 OID 60201)
-- Name: dbschema dbschema_id_key; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.dbschema
    ADD CONSTRAINT dbschema_id_key UNIQUE (id);


--
-- TOC entry 2771 (class 2606 OID 60165)
-- Name: queue queue_id_key; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.queue
    ADD CONSTRAINT queue_id_key UNIQUE (id);


--
-- TOC entry 2773 (class 2606 OID 60176)
-- Name: servicestatus servicestatus_id_key; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.servicestatus
    ADD CONSTRAINT servicestatus_id_key UNIQUE (id);


--
-- TOC entry 2775 (class 2606 OID 60189)
-- Name: sourcefile sourcefile_id_key; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.sourcefile
    ADD CONSTRAINT sourcefile_id_key UNIQUE (id);


--
-- TOC entry 2761 (class 2606 OID 60128)
-- Name: work_load workload_id_key; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.work_load
    ADD CONSTRAINT workload_id_key UNIQUE (id);


--
-- TOC entry 2779 (class 2606 OID 60217)
-- Name: work_queue workqueue_id_key; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.work_queue
    ADD CONSTRAINT workqueue_id_key UNIQUE (id);


--
-- TOC entry 2781 (class 2606 OID 60531)
-- Name: work_queue workqueue_unique; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.work_queue
    ADD CONSTRAINT workqueue_unique UNIQUE (workloadid, queuetype);


--
-- TOC entry 2782 (class 2606 OID 60202)
-- Name: dbschema dbschema_workloadid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.dbschema
    ADD CONSTRAINT dbschema_workloadid_fkey FOREIGN KEY (workloadid) REFERENCES public.work_load(id);


--
-- TOC entry 2783 (class 2606 OID 60218)
-- Name: work_queue workqueue_workloadid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.work_queue
    ADD CONSTRAINT workqueue_workloadid_fkey FOREIGN KEY (workloadid) REFERENCES public.work_load(id);


-- Completed on 2022-04-01 08:59:00

--
-- PostgreSQL database dump complete
--

