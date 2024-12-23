using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

[Serializable]
public class PruebasRol : MonoBehaviour
{
    // Create a field for the save file.
    string saveFile;


    void Awake()
    {
        // Update the path once the persistent path exists.
        saveFile = "Assets/Resources/Jsons" + "/RazasEsp.json";
        Debug.Log(Application.persistentDataPath);
    }

    // Start is called before the first frame update
    void Start()
    {
        // writeFile();
        //readFile();
        //OverWrite();
        //WriteListFile();
        //LoadListObjetos(CargarObjetos());
        LoadList(CargarClases());
        //PruebaClasePicaro();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OverWrite()
    {
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.

            Raza r = JsonConvert.DeserializeObject<Raza>(fileContents);
            List<Raza> razas = new List<Raza>();
            razas=JsonConvert.DeserializeObject<List<Raza>>(fileContents);
            foreach(Raza ra in razas)
            {
                Debug.Log(ra.ToString());
            }


            /*______________________________________________________________________*/

            /*
            Raza raza= new Raza();
            Dictionary<E_Caracteristicas, int> caracteristicas = new Dictionary<E_Caracteristicas, int>();
            caracteristicas.Add(E_Caracteristicas.CONSTITUCION, 2);
            List<Atributo> atributos = new List<Atributo>();
            atributos.Add(new Atributo("PIEL FERREA", "DURO COMO LAS ROCAS"));
            atributos.Add(new Atributo("BAJITO PERO MATON", "TAMA�O REDUCIDO"));
            List<E_Habilidades> habilidades = new List<E_Habilidades>();
            habilidades.Add(E_Habilidades.RELIGION);
            habilidades.Add(E_Habilidades.INTERPRETACION);
            habilidades.Add(E_Habilidades.PERSUASION);
            r.Subraza.Add(new Subraza(E_Subraza.ENANO_DE_LAS_MONTA�AS, caracteristicas, atributos));
            r.Habilidades = habilidades;
            r.Atributos = atributos;
            // Configurar JsonSerializerSettings para que use nombres de propiedades en min�sculas
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver() // hace que las propiedades empiecen en min�scula
            };
            settings.Converters.Add(new StringEnumConverter());

            // Serialize the object into JSON and save string.
            string jsonString = JsonConvert.SerializeObject(raza, settings);



            // Write JSON to file.
            File.WriteAllText(saveFile, jsonString);*/

        }
    }


    public void readFile()
    {
        // Does the file exist?
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.

            Raza r=JsonConvert.DeserializeObject<Raza>(fileContents);
            Debug.Log(r.ToString());
        }
    }

    public void writeFile()
    {
        Raza r= new Raza();
        Dictionary<E_Caracteristicas, int> caracteristicas = new Dictionary<E_Caracteristicas, int>();
        caracteristicas.Add(E_Caracteristicas.CONSTITUCION, 2);
        List<Atributo> atributos = new List<Atributo>();
        atributos.Add(new Atributo("PIEL FERREA","DURO COMO LAS ROCAS"));
        atributos.Add(new Atributo("BAJITO PERO MATON", "TAMA�O REDUCIDO"));
        List<E_Habilidades>habilidades = new List<E_Habilidades>();
        habilidades.Add(E_Habilidades.RELIGION);
        habilidades.Add(E_Habilidades.INTERPRETACION);
        habilidades.Add(E_Habilidades.PERSUASION);
        r.Subraza.Add(new Subraza(E_Subraza.ENANO_DE_LAS_MONTA�AS,caracteristicas,atributos));
        r.Habilidades=habilidades;
        r.Atributos=atributos;
        // Configurar JsonSerializerSettings para que use nombres de propiedades en min�sculas
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ContractResolver = new CamelCasePropertyNamesContractResolver() // hace que las propiedades empiecen en min�scula
        };
        settings.Converters.Add(new StringEnumConverter());

        // Serialize the object into JSON and save string.
        string jsonString = JsonConvert.SerializeObject(r,settings);

       

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }


    private void WriteListFile()
    {
       
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ContractResolver=new CamelCasePropertyNamesContractResolver()
        };
        settings.Converters.Add(new StringEnumConverter());
        string jsonString= JsonConvert.SerializeObject(CargarRazas(),settings);
        File.WriteAllText(saveFile,jsonString);
    }



    private void LoadListPrueba(Dictionary<string, List<object>> jsonPorGuardar)
    {
        string pathload = jsonPorGuardar.Keys.First();
        if (File.Exists(pathload))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(pathload);

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.

            List<object> listObjects = JsonConvert.DeserializeObject<List<object>>(fileContents);

            foreach (object obj in listObjects)
            {
                //Debug.Log(r.Nombre+":"+r.MejoraCaracteristicas.First().Key.ToString());
                Debug.Log(obj.ToString());
            }

        }
    }

    private void LoadList(Dictionary<string, List<Objeto>> jsonObjetosPorGuardar)
    {
        string pathload = jsonObjetosPorGuardar.Keys.First();
        if (File.Exists(pathload) && pathload == "meme")
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(pathload);

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.

            List<Objeto> listObjects = JsonConvert.DeserializeObject<List<Objeto>>(fileContents);

            foreach (Objeto obj in listObjects)
            {
                //Debug.Log(r.Nombre+":"+r.MejoraCaracteristicas.First().Key.ToString());
                Debug.Log(obj.ToString());
            }

        }
        else
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            settings.Converters.Add(new StringEnumConverter());

            string jsonString = JsonConvert.SerializeObject(jsonObjetosPorGuardar.Values.First(), settings);
            Debug.Log("Json creado en " + pathload);
            File.WriteAllText(pathload, jsonString);
        }
    }

    private void LoadList(Dictionary<string, List<Clase>> jsonClasesPorGuardar)
    {
        string pathload = jsonClasesPorGuardar.Keys.First();
        if (File.Exists(pathload) && pathload == "meme")
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(pathload);

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.

            List<Clase> listClases = JsonConvert.DeserializeObject<List<Clase>>(fileContents);

            foreach (Clase obj in listClases)
            {
                //Debug.Log(r.Nombre+":"+r.MejoraCaracteristicas.First().Key.ToString());
                Debug.Log(obj.ToString());
            }

        }
        else
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            settings.Converters.Add(new StringEnumConverter());

            string jsonString = JsonConvert.SerializeObject(jsonClasesPorGuardar.Values.First(), settings);
            Debug.Log("Json creado en " + pathload);
            File.WriteAllText(pathload, jsonString);
        }
    }

    #region CargaDatos

    private Dictionary<string, List<Raza>> CargarRazas()
    {
        Dictionary<string,List<Raza>> razasFinales= new Dictionary<string, List<Raza>>();
        string pathload = "Assets/Resources/Jsons/RazasEsp.json";
        List<Raza>razas = new List<Raza>();
        Subraza subraza;
        Raza r;
        #region EnanoCreacion
        r = new Raza();
        r.Codigo = 1;
        r.Nombre = E_Razas.ENANO;
        r.EdadMaxima = 300;
        r.Alienamiento = E_Alienamiento.LEGAL;
        r.Tama�oMinimo = 122;
        r.Tama�oMaximo = 152;
        r.Velocidad = 25;
        r.MejoraCaracteristicas.Add(E_Caracteristicas.CONSTITUCION, 2);
        r.Atributos.Add(new Atributo("Visi�n en la Oscuridad", "Acostumbrado a la vida bajo tierra, puedes ver bien en la oscuridad o con poca luz. Eres capaz de percibir hasta a 60 pies en luz tenue comosi hubiera luz bri llante, y esa misma distancia en la oscuridad como si hubiera luz tenue. Eso s�, no puedes distinguir colores en la oscuridad, solo tonos de gris."));
        r.Atributos.Add(new Atributo("Resistencia Enana", "Tienes ventaja en las tiradas de salvaci�n contra veneno y posees resistencia al da�o de veneno"));
        r.Atributos.Add(new Atributo("Entrenamientode Combate Enano", "Eres competente con hachas de guerra, hachasde mano, martillos de guerra y martillos ligeros."));
        r.Atributos.Add(new Atributo("Competencia con Herramientas", "Eres competente con las herramientas de artesano que elijas de entre las siguientes:herramientas de alba�il, herramientas de herrero o suministros de cervecero"));
        r.Atributos.Add(new Atributo("Afinidad con la Piedra", "Cuando hagas una prueba de Inteligencia (Historia) que tenga relaci�n con el origen de un trabajo en piedra, se te considerar� competente en la habilidad Historia y a�adir�s dos veces tu bonificador por competencia a la tirada, en lugar de solo una"));
        r.Atributos.Add(new Atributo("Idiomas", "Puedes hablar, leer y escribir en com�n y enano. El idioma enano est� lleno de consonantes duras y sonidos guturales, y estas peculiaridades se traslucen en la forma que tienen losenanos de pronunciar cualquier otro lenguaje que conozcan"));
        #region SubrazasEnanosCreacion
        subraza= new Subraza();
        subraza.Nombre = E_Subraza.ENANO_DE_LAS_COLINAS;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.SABIDURIA, 1);
        subraza.Rasgos.Add(new Atributo("Aguante Enano", "Tus puntos de golpe m�ximosse incrementan en 1, y aumentar�n en 1 m�s cada vez que subas un nivel."));
        r.Subraza.Add(subraza);
        subraza = new Subraza();
        subraza.Nombre = E_Subraza.ENANO_DE_LAS_MONTA�AS;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.FUERZA, 2);
        subraza.Rasgos.Add(new Atributo(" Entrenamiento con Armadura Enana", "Eres competente con armaduras ligeras y medias."));
        r.Subraza.Add(subraza);
        #endregion SubrazasEnanosCreacion
        razas.Add(r);
        #endregion  EnanoCreacion
        #region ElfoCreacion
        r = new Raza();
        r.Codigo = 2;
        r.Nombre = E_Razas.ELFO;
        r.EdadMaxima = 700;
        r.Alienamiento = E_Alienamiento.BUENO;
        r.Tama�oMinimo = 152;
        r.Tama�oMaximo = 183;
        r.Velocidad = 30;
        r.MejoraCaracteristicas.Add(E_Caracteristicas.DESTREZA, 2);
        r.Atributos.Add(new Atributo("Visi�n en la Oscuridad", "Acostumbrado a la penumbra de los bosques y el cielo nocturno, puedes ver bien en la oscuridad o con poca luz. Hasta a un m�ximo de 60 pies, eres capaz de ver con luz tenue comosi hubiera luz brillante y en la oscuridad como si hubiera luz tenue. Eso s�, no puedes distinguir colores en la oscuridad, solo tonos de gris."));
        r.Atributos.Add(new Atributo("Sentidos Agudos", "Eres competente en la habilidad Percepci�n"));
        r.Atributos.Add(new Atributo("Linaje Fe�rico", "Tienes ventaja en las tiradas de salvaci�n para evitar ser hechizado y la magia no puede dormirte."));
        r.Atributos.Add(new Atributo("Trance", "Los elfos no necesitan dormir. Meditan profundamente, en un estado semiconsciente,durante 4 horas al d�a. La palabra en com�n para referirse a esta meditaci�n es �trance�. Mientras meditas, experimentas algo parecido a sue�os,que en realidad son ejercicios mentales que se han vuelto autom�ticos tras a�os de pr�ctica. Este trance es suficiente para obtener los mismos beneficios que un humano recibe de 8 horas de sue�o"));
        r.Atributos.Add(new Atributo("Idiomas", "Puedes hablar, leer y escribir en com�n y elfo. El idioma elfo es fluido, con entonaciones sutiles y una gram�tica compleja. La literatura �lfica es rica y variada, y sus canciones y poemas son famosos entre el resto de razas. Muchos bardos aprenden este idioma para poder a�adir baladas �lficas asus repertorios."));
        r.Habilidades.Add(E_Habilidades.PERCEPCION);
        #region SubrazasELfosCreacion
        subraza = new Subraza();
        subraza.Nombre = E_Subraza.ALTO_ELFO;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.INTELIGENCIA, 1);
        subraza.Rasgos.Add(new Atributo("Entrenamiento con Armas Elficas", "Eres competente con espadas cortas, espadas largas, arcos cortos y arcos largos."));
        subraza.Rasgos.Add(new Atributo("Truco", "Conoces un truco de tu elecci�n escogido de entre los de la lista de conjuros de mago. La Inteligencia es tu aptitud m�gica para lanzarlo."));
        subraza.Rasgos.Add(new Atributo("Idioma Adicional", "Puedes hablar, leer y escribir un idioma adicional de tu elecci�n."));

        r.Subraza.Add(subraza);
        subraza = new Subraza();
        subraza.Nombre = E_Subraza.ELFO_DE_LOS_BOSQUES;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.SABIDURIA,1);
        subraza.Rasgos.Add(new Atributo("Entrenamiento con Armas �lf�cas", "Eres competente con espadas cortas, espadas largas, arcos cortos y arcos largos."));
        subraza.Rasgos.Add(new Atributo("Pies Veloces", "Tu velocidad caminando base aumenta a 35 pies."));
        subraza.Rasgos.Add(new Atributo(" M�scara de la Naturaleza", "Puedes intentar esconderte incluso cuando est�s en un lugar solo ligeramente oscuro, siempre que lo que te tape sea follaje, una lluvia fuerte, nieve que cae, niebla o cualquier otro fen�meno natural."));

        r.Subraza.Add(subraza);
        subraza = new Subraza();
        subraza.Nombre = E_Subraza.DROW;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.CARISMA, 1);
        subraza.Rasgos.Add(new Atributo("Visi�n en la Oscuridad Superior", "Tu visi�n en la oscuridad posee un radio de 120 pies."));
        subraza.Rasgos.Add(new Atributo("Sensibilidad a la Luz Solar", "Tienes desventaja en las tiradas de ataque y las pruebas de Sabidur�a (Percepci�n) que dependan de la vista realizadas cuando t�, el objetivo de tu ataque o lo que sea que intentas percibir est� bajo la luz solar directa."));
        subraza.Rasgos.Add(new Atributo("Magia Drow", "Conoces el truco luces danzantes. Cuando llegas a nivel 3, puedes lanzar el conjuro fuego fe�rico una vez usando este atributo y recuperas la capacidad para hacerlo tras realizar un descanso largo. Cuando alcanzasel nivel 5, eres capaz de lanzar el conjuro oscuridad una vez empleando este atributo y recuperas la capacidad para hacerlo tras realizar un descanso largo. El Carisma es tu aptitud m�gica para estos conjuros."));
        subraza.Rasgos.Add(new Atributo("Entrenamiento con Armas Drow", " Erescompetente con\r\n estoques, espadas cortas y ballestas de mano."));
        r.Subraza.Add(subraza);
        #endregion SubrazasELfosCreacion
        razas.Add(r);
        #endregion  ElfoCreacion
        #region MedianoCreacion
        r = new Raza();
        r.Codigo = 3;
        r.Nombre = E_Razas.MEDIANO;
        r.EdadMaxima = 200;
        r.Alienamiento = E_Alienamiento.LEGAL_BUENO;
        r.Tama�oMinimo = 91;
        r.Tama�oMaximo = 93;
        r.Velocidad = 25;
        r.MejoraCaracteristicas.Add(E_Caracteristicas.DESTREZA, 2);
        r.Atributos.Add(new Atributo("Afortunado", "Cuando saques un 1 en el dado al hacer una tirada de ataque, prueba de caracter�stica o tirada de salvaci�n, puedes volver a tirar el dado, pero tendr�s que utilizar el resultado nuevo."));
        r.Atributos.Add(new Atributo("Valiente", "Posees ventaja en las tiradas de salvaci�n para evitar ser asustado."));
        r.Atributos.Add(new Atributo("Agilidad de Mediano", "Puedes movertea trav�s del espacio ocupado por una criatura cuyo tama�o sea, al menos, una categor�a superior al tuyo."));
        r.Atributos.Add(new Atributo("Idiomas", "Puedes hablar, leer y escribir en com�n y mediano.El idioma de los medianos no es secreto, pero estos son reticentes a compartirlo con otros. Escriben poco, por lo que no tienen una gran producci�n literaria. No obstante, su tradici�n oral es muy rica. Pr�cticamente todos los medianos hablan com�n para poder comunicarse con losque viven junto a ellos o en los lugares por los que viajan."));
        #region SubrazasMedianosCreacion
        subraza = new Subraza();
        subraza.Nombre = E_Subraza.PIESLIGEROS;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.CARISMA, 1);
        subraza.Rasgos.Add(new Atributo("Sigiloso por Naturaleza", "Puedes intentar esconderte incluso tras una criatura cuyo tama�o sea, al menos, una categor�a superior al tuyo."));
        
        r.Subraza.Add(subraza);


        subraza = new Subraza();
        subraza.Nombre = E_Subraza.FORNIDO;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.CONSTITUCION, 1);
        subraza.Rasgos.Add(new Atributo("Resistencia de Fornido", "Tienes ventaja en las tiradas de salvaci�n contra veneno y posees resistencia al da�o de veneno."));
        r.Subraza.Add(subraza);
        #endregion SubrazasMedianosCreacion
        razas.Add(r);
        #endregion  MedianoCreacion
        #region HumanoCreacion
        r = new Raza();
        r.Codigo = 4;
        r.Nombre = E_Razas.HUMANO;
        r.EdadMaxima = 90;
        r.Tama�oMinimo = 152;
        r.Tama�oMaximo = 183;
        r.Velocidad = 30;
        r.MejoraCaracteristicas.Add(E_Caracteristicas.FUERZA, 1);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.DESTREZA, 1);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.CONSTITUCION, 1);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.INTELIGENCIA,1);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.SABIDURIA,1);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.CARISMA, 1);


        r.Atributos.Add(new Atributo("Idiomas", "Idiomas\", \"Puedes hablar, leer y escribir com�n y un idioma adicional de tu elecci�n. Los humanos normalmente aprenden los idiomas de aquellos con los que se relacionan, aunque sean dialectos poco conocidos. Les gusta adornar su habla con palabras tomadas de otras lenguas: maldiciones oreas, expresiones musicales elfas, t�rminos militares enanos, y as�."));
        razas.Add(r);
        #endregion  HumanoCreacion
        #region DraconianoCreacion
        r = new Raza();
        r.Codigo = 5;
        r.Nombre = E_Razas.DRACONICO;
        r.EdadMaxima = 80;
        r.Tama�oMinimo = 183;
        r.Tama�oMaximo = 213;
        r.Velocidad = 30;
        r.Alienamiento = E_Alienamiento.BUENO;
        r.MejoraCaracteristicas = new Dictionary<E_Caracteristicas, int>();
        r.MejoraCaracteristicas.Add(E_Caracteristicas.FUERZA, 2);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.CARISMA, 1);

        r.Atributos = new List<Atributo>();
        r.Atributos.Add(new Atributo("Linaje Drac�nico", "Posees la sangre de dragones. Escoge de qu� tipoen la tabla �linaje drac�nico�. Tu Ataque de Aliento y Resistencia al Da�o vendr�n determinadas por el tipo de drag�n, tal y como se indica en dicha tabla."));
        r.Atributos.Add(new Atributo("Ataque de Aliento", "Puedes utilizar tu acci�n para exhalar energ�a destructora. Tu Linaje Drac�nico determina el tama�o, forma y tipo de da�o del aliento. Cuando uses tu Ataque de Aliento, las criaturas que se encuentren en la zona cubierta por este deber�n hacer una tirada de salvaci�n, cuyo tipo viene definido por tu linaje. La CD de esta tirada de salvaci�n es de 8 + tu modificador por Constituci�n + tu bonilicador por competencia. Las criaturas sufrir�n 2d6 de da�o si fallan la tirada o la mitad de ese da�o si la superan. El da�o aumenta a 3d6 cuando alcanzas el nivel 6, a 4d6 a nivel 11 y a 5d6 a nivel 16. Una vez utilizado el Ataque de Aliento, no podr�s volver a emplearlo hasta que finalices un descanso corto o largo."));
        r.Atributos.Add(new Atributo("Resistencia al Da�o", "Posees resistencia al tipo de da�o asociado a tu Linaje Drac�nico."));
        r.Atributos.Add(new Atributo("Idiomas", "Puedes hablar, leer y escribir en com�n y drac�nico. Se piensa que el drac�nico es uno de los idiomas m�s antiguos y suele emplearse en el estudio de la magia. Resulta �spero a o�dos de la mayor�a de criaturas y utiliza muchas consonantes duras y sibilantes."));
        razas.Add(r);
        #endregion  DraconianoCreacion
        #region GnomoCreacion
        r = new Raza();
        r.Codigo = 6;
        r.Nombre = E_Razas.GNOMO;
        r.EdadMaxima = 500;
        r.Tama�oMinimo = 92;
        r.Tama�oMaximo = 122;
        r.Velocidad = 25;
        r.Alienamiento = E_Alienamiento.BUENO;
        r.MejoraCaracteristicas = new Dictionary<E_Caracteristicas, int>();
        r.MejoraCaracteristicas.Add(E_Caracteristicas.INTELIGENCIA, 2);
        #region SubrazasGnomoCreacion
        subraza = new Subraza();
        subraza.Nombre = E_Subraza.GNOMO_DE_LOS_BOSQUES;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.DESTREZA, 1);
        subraza.Rasgos.Add(new Atributo("Ilusionista Innato", "Conoces el truco ilusi�n menor. La Inteligencia es tu aptitud m�gica para lanzarlo."));
        subraza.Rasgos.Add(new Atributo("Hablar con las Bestezuelas", "Puedes comunicar ideas sencillas a bestias de tama�o Peque�o o inferior usando gestos y sonidos. Los gnomos de los bosques adoran a los animales y en ocasiones adoptan ardillas, tejones, conejos, topos, p�jaros carpinteros y otras criaturas similares como mascotas."));
        r.Subraza.Add(subraza);
        subraza = new Subraza();
        subraza.Nombre = E_Subraza.GNOMO_DE_LAS_ROCAS;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.CONSTITUCION, 1);
        subraza.Rasgos.Add(new Atributo("Saber del Artificiero", "Conoces el truco ilusi�n menor. La Inteligencia es tu aptitud m�gica para lanzarlo."));
        subraza.Rasgos.Add(new Atributo("Manilas", "Eres competente con las siguientes herramientas de artesano: herramientasde manitas. Us�ndolas,puedes invertir 1 hora y materiales valorados en 10 po para construir un dispositivo de relojer�a de tama�o Diminuto(CA 5,1 punto de golpe).Este dispositivo deja de funcionar pasadas 24 horas(salvo si dedicas 1 hora a repararlo para mantenerlo a punto) o si usas una acci�n para desmantelarlo. De hacer esto �ltimo, puedes recuperar los materiales que usaste en la construcci�n. Puedes tener hasta tres dispositivos de este tipo funcionando al mismo tiempo. Cada vez que construyas un dispositivo, elige de entre las siguientes opciones: Juguete de relojer�a. Este juguete mec�nico posee forma de un animal,monstruo o persona. Como,por ejemplo, de una rana,un rat�n,un drag�no un soldado. Tras depositarlo en el suelo, se mover� 5 pies en una direcci�n aleatoria en cada uno de tus turnos.Hace ruidos apropiados para el ser que representa. Encendedor. Este dispositivo produce una llama en miniatura, que puedes utilizar para encder una vela, antorcha u hoguera. Para usarlo es necesario invertir una acci�n. Caja de m�sica. Al abrirse, esta caja de m�sica reproduce una �nica canci�n a un volumen moderado. La caja deja de sonar cuando la canci�n se acaba o es cerrada."));
        r.Subraza.Add(subraza);
        #endregion SubrazasGnomoCreacion
        r.Atributos.Add(new Atributo("Visi�n en la Oscuridad.", "Acostumbrado a la vida bajo tierra, puedes ver bien en la oscuridad o con poca luz. Eres capaz de percibir hasta a 60 pies en luz tenue como si hubiera luz brillante, y esa misma distancia enla oscuridad como si hubiera luz tenue. Eso s�, no puedes distinguir colores en la oscuridad, solo tonos de gris."));
        r.Atributos.Add(new Atributo("Astucia Gnoma", "Tienes ventaja en las tiradas de salvaci�n de Inteligencia, Sabidur�a y Carisma contra magia."));
        r.Atributos.Add(new Atributo("Idiomas", "Puedes hablar, leer y escribir en com�n y gnomo. El idioma gnomo, que se escribe con el alfabeto enano, es famoso por la cantidad de tratados t�cnicos y cat�logos de conocimiento sobre el mundo natural escritos en �l."));

        razas.Add(r);
        #endregion  GnomoCreacion
        #region SemiElfoCreacion
        r = new Raza();
        r.Codigo = 7;
        r.Nombre = E_Razas.SEMIELFO;
        r.EdadMaxima = 180;
        r.Tama�oMinimo = 152;
        r.Tama�oMaximo = 183;
        r.Velocidad = 30;
        r.Alienamiento = E_Alienamiento.CAOTICO;
        r.MejoraCaracteristicas = new Dictionary<E_Caracteristicas, int>();
        r.MejoraCaracteristicas.Add(E_Caracteristicas.CARISMA, 1);
        
        r.Atributos.Add(new Atributo("Visi�n en la Oscuridad.", "Debido a tu sangre �lfica, puedes ver bien en la oscuridad o con poca luz. Eres capaz de percibir hasta a 60 pies en luz tenue como si hubiera luz brillante, y esa misma distancia en la oscuridad como si hubiera luz tenue. Eso s�, no puedes distinguir coloresen la oscuridad, solo tonos de gris."));
        r.Atributos.Add(new Atributo("Linaje Fe�rico", "Tienes ventaja en las tiradas de salvaci�n para evitar ser hechizado y la magia no puede dormirte."));
        r.Atributos.Add(new Atributo("Vers�til con Habilidades", "Ganas competencia en dos habilidades de tu elecci�n."));
        r.Atributos.Add(new Atributo("Idiomas", "Puedes hablar, leer y escribir com�n, elfo y un idioma adicional de tu elecci�n."));
        razas.Add(r);
        #endregion  SemiElfoCreacion
        #region SemiOrcoCreacion
        r = new Raza();
        r.Codigo = 8;
        r.Nombre = E_Razas.SEMIORCO;
        r.EdadMaxima = 75;
        r.Tama�oMinimo = 152;
        r.Tama�oMaximo = 183;
        r.Velocidad = 30;
        r.Alienamiento = E_Alienamiento.CAOTICO;
        r.MejoraCaracteristicas= new Dictionary<E_Caracteristicas, int>();
        r.MejoraCaracteristicas.Add(E_Caracteristicas.FUERZA, 2);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.CONSTITUCION, 1);

        r.Atributos = new List<Atributo>();
        r.Atributos.Add(new Atributo("Visi�n en la Oscuridad.", "Debido a tu sangre orca, puedes ver bien en la oscuridad o con poca luz. Eres capaz de percibir hasta a 60 pies en luz tenue comosi hubiera luz brillante, y esa misma distancia en la oscuridad como si hubiera luz tenue. Eso s�, no puedes distinguir colores en la oscuridad, solo tonos de gris."));
        r.Atributos.Add(new Atributo("Amenazador", "Eres competente en la habilidad Intimidaci�n."));
        r.Atributos.Add(new Atributo("Aguante Incansable", "Cuando tus puntos de golpe se reducen a 0 pero no mueres instant�neamente, puedes volver a tener 1 punto de golpe. Una vez utilizado este atributo, deber�s terminar un descanso largo para poder volver a usarlo otra vez."));
        r.Atributos.Add(new Atributo("Ataques Salvajes", "Cuando hagas un cr�tico con un ataque con arma cuerpo a cuerpo, podr�s tirar uno de los dados de da�o del arma una vez m�s y a�adir el resultado al da�o adicional causado por el cr�tico"));
        r.Atributos.Add(new Atributo(" Idiomas", "Puedes hablar, leer y escribir en com�n y orco. El orco es un idioma �spero y severo, con consonantes duras. No tiene escritura propia, pero para transcribirlo se usa el alfabeto enano."));
        razas.Add(r);

        #endregion  SemiOrcoCreacion
        #region TieflingCreacion
        r = new Raza();
        r.Codigo = 9;
        r.Nombre = E_Razas.TIEFLING;
        r.EdadMaxima = 100;
        r.Tama�oMinimo = 152;
        r.Tama�oMaximo = 183;
        r.Velocidad = 30;
        r.Alienamiento = E_Alienamiento.MALVADO;
        r.MejoraCaracteristicas = new Dictionary<E_Caracteristicas, int>();
        r.MejoraCaracteristicas.Add(E_Caracteristicas.CARISMA, 2);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.INTELIGENCIA, 1);

        r.Atributos.Add(new Atributo("Visi�n en la Oscuridad.", "Debido a tu sangre infernal, puedes ver bien en la oscuridad o con poca luz. Eres capaz de percibir hasta a 60 pies en luz tenue como si hubiera luz brillante, y esa misma distancia en la oscuridad como si hubiera luz tenue. Eso s�, no puedes distinguir colores en la oscuridad, solo tonos de gris"));
        r.Atributos.Add(new Atributo("Resistencia Infernal", " Posees resistencia al da�o de fuego."));
        r.Atributos.Add(new Atributo("Linaje Infernal", "Conoces el truco taumaturgia. Cuando llegas a nivel 3, puedes lanzar el conjuro reprensi�n infernal como conjuro de nivel 2 una vez usando este atributo y recuperas la capacidad para hacerlo tras realizar un descanso largo. Cuando alcanzas el nivel 5, eres capaz de lanzar el conjuro oscuridad una vez empleando este atributo y recuperas la capacidad para hacerlo tras realizar un descanso largo. El Carismaes tu aptitud m�gica para estos conjuros."));
        r.Atributos.Add(new Atributo("Idiomas", "Puedes hablar, leery escribir en com�n e infernal."));
        razas.Add(r);
        #endregion  TieflingCreacion
        razasFinales.Add(pathload,razas);
        return razasFinales;
    }


    private Dictionary<string,List<Objeto>> CargarObjetos()
    {
        Dictionary<string,List<Objeto>> objetosFinales = new Dictionary<string,List<Objeto>>();
        string pathload = "Assets/Resources/Jsons/ObjetosEsp.json";
        List<Objeto> objectos=new List<Objeto>();
        Objeto objeto;
        Arma arma;
        Armadura armadura;
        Paquete paquete;
        #region ObjetosCreados
        #region CrearObjeto1
        objeto = new Objeto();
        objeto.Codigo = 1;
        objeto.Nombre = "Abaco";
        objeto.SetValor(2);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto1
        #region CrearObjeto2
        objeto = new Objeto();
        objeto.Codigo = 2;
        objeto.Nombre = "Abrojos";
        objeto.SetValor(2);
        objeto.SetPeso(2);
        objeto.SetCantidad(20);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto2
        #region CrearObjeto3
        objeto = new Objeto();
        objeto.Codigo = 3;
        objeto.Nombre = "Aceite";
        objeto.SetValor(2);
        objeto.SetPeso(1);
        objeto.SetCantidad(20);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion CrearObjeto3
        #region CrearObjeto4
        objeto = new Objeto();
        objeto.Codigo = 4;
        objeto.Nombre = "Aceite";
        objeto.SetValor(2);
        objeto.SetPeso(1);
        objeto.SetCantidad(20);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion CrearObjeto4
        #region CrearObjeto5
        objeto = new Objeto();
        objeto.Codigo = 5;
        objeto.Nombre = "Acido";
        objeto.SetValor(25);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto5
        #region CrearObjeto6
        objeto = new Objeto();
        objeto.Codigo = 6;
        objeto.Nombre = "Agua Bendita";
        objeto.SetValor(25);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto6
        #region CrearObjeto7
        objeto = new Objeto();
        objeto.Codigo = 7;
        objeto.Nombre = "Aljaba";
        objeto.SetValor(1);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto7
        #region CrearObjeto8
        objeto = new Objeto();
        objeto.Codigo = 8;
        objeto.Nombre = "Anillo de sellar";
        objeto.SetValor(5);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto8
        #region CrearObjeto9
        objeto = new Objeto();
        objeto.Codigo = 9;
        objeto.Nombre = "Antitoxina";
        objeto.SetValor(50);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto8
        #region CrearObjeto10
        objeto = new Objeto();
        objeto.Codigo = 10;
        objeto.Nombre = "Antorcha";
        objeto.SetValor(1);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PC;
        objectos.Add(objeto);
        #endregion CrearObjeto10
        #region CrearObjeto11
        objeto = new Objeto();
        objeto.Codigo = 11;
        objeto.Nombre = "Ariete Portatil";
        objeto.SetValor(4);
        objeto.SetPeso(35);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto11
        #region CrearObjeto12
        objeto = new Objeto();
        objeto.Codigo = 12;
        objeto.Nombre = "Balanza de mercader";
        objeto.SetValor(5);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto12
        #region CrearObjeto13
        objeto = new Objeto();
        objeto.Codigo = 13;
        objeto.Nombre = "Barril";
        objeto.SetValor(2);
        objeto.SetPeso(70);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto13
        #region CrearObjeto14
        objeto = new Objeto();
        objeto.Codigo = 14;
        objeto.Nombre = "Bolas de metal";
        objeto.SetValor(1);
        objeto.SetPeso(2);
        objeto.SetCantidad(1000);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto14
        #region CrearObjeto15
        objeto = new Objeto();
        objeto.Codigo = 15;
        objeto.Nombre = "Bolsa";
        objeto.SetValor(5);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion CrearObjeto15
        #region CrearObjeto16
        objeto = new Objeto();
        objeto.Codigo = 16;
        objeto.Nombre = "Botella de cristal";
        objeto.SetValor(2);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto16
        #region CrearObjeto17
        objeto = new Objeto();
        objeto.Codigo = 17;
        objeto.Nombre = "Cadena";
        objeto.SetValor(5);
        objeto.SetPeso(10);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto17
        #region CrearObjeto18
        objeto = new Objeto();
        objeto.Codigo = 18;
        objeto.Nombre = "Campana";
        objeto.SetValor(1);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto18
        #region CrearObjeto19
        objeto = new Objeto();
        objeto.Codigo = 19;
        objeto.Nombre = "Cristal";
        objeto.SetValor(10);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto19
        #region CrearObjeto20
        objeto = new Objeto();
        objeto.Codigo = 20;
        objeto.Nombre = "Baston";
        objeto.SetValor(5);
        objeto.SetPeso(4);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto20
        #region CrearObjeto21
        objeto = new Objeto();
        objeto.Codigo = 21;
        objeto.Nombre = "Orbe";
        objeto.SetValor(20);
        objeto.SetPeso(3);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto21
        #region CrearObjeto22
        objeto = new Objeto();
        objeto.Codigo = 22;
        objeto.Nombre = "Vara";
        objeto.SetValor(10);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto22
        #region CrearObjeto23
        objeto = new Objeto();
        objeto.Codigo = 23;
        objeto.Nombre = "Varita";
        objeto.SetValor(10);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto23
        #region CrearObjeto24
        objeto = new Objeto();
        objeto.Codigo = 24;
        objeto.Nombre = "Baston de madera";
        objeto.SetValor(5);
        objeto.SetPeso(4);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto24
        #region CrearObjeto25
        objeto = new Objeto();
        objeto.Codigo = 25;
        objeto.Nombre = "Rama de muerdago";
        objeto.SetValor(1);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto25
        #region CrearObjeto26
        objeto = new Objeto();
        objeto.Codigo = 26;
        objeto.Nombre = "T�tem";
        objeto.SetValor(1);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto26
        #region CrearObjeto27
        objeto = new Objeto();
        objeto.Codigo = 27;
        objeto.Nombre = "Varita de tejo";
        objeto.SetValor(10);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto27
        #region CrearObjeto28
        objeto = new Objeto();
        objeto.Codigo = 28;
        objeto.Nombre = "Cantimplora";
        objeto.SetValor(2);
        objeto.SetPeso(5);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion CrearObjeto28
        #region CrearObjeto29
        objeto = new Objeto();
        objeto.Codigo = 29;
        objeto.Nombre = "Ca�a de pescar";
        objeto.SetValor(1);
        objeto.SetPeso(4);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto29
        #region CrearObjeto30
        objeto = new Objeto();
        objeto.Codigo = 30;
        objeto.Nombre = "Catalejo";
        objeto.SetValor(1000);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto30
        #region CrearObjeto31
        objeto = new Objeto();
        objeto.Codigo = 31;
        objeto.Nombre = "Cerradura";
        objeto.SetValor(10);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto31
        #region CrearObjeto32
        objeto = new Objeto();
        objeto.Codigo = 32;
        objeto.Nombre = "Cesta";
        objeto.SetValor(4);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion CrearObjeto32
        #region CrearObjeto33
        objeto = new Objeto();
        objeto.Codigo = 33;
        objeto.Nombre = "Cofre";
        objeto.SetValor(5);
        objeto.SetPeso(25);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto33
        #region CrearObjeto34
        objeto = new Objeto();
        objeto.Codigo = 34;
        objeto.Nombre = "Cuerda de ca�amo";
        objeto.SetValor(1);
        objeto.SetPeso(10);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto34
        #region CrearObjeto35
        objeto = new Objeto();
        objeto.Codigo = 35;
        objeto.Nombre = "Cuerda de seda";
        objeto.SetValor(10);
        objeto.SetPeso(5);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto35
        #region CrearObjeto36
        objeto = new Objeto();
        objeto.Codigo = 36;
        objeto.Nombre = "Cubo";
        objeto.SetValor(5);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PC;
        objectos.Add(objeto);
        #endregion CrearObjeto36
        #region CrearObjeto37
        objeto = new Objeto();
        objeto.Codigo = 37;
        objeto.Nombre = "Escalera";
        objeto.SetValor(1);
        objeto.SetPeso(25);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion CrearObjeto37
        #region CrearObjeto38
        objeto = new Objeto();
        objeto.Codigo = 38;
        objeto.Nombre = "Espejito de acero";
        objeto.SetValor(5);
        objeto.SetPeso(0.5f);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto38
        #region CrearObjeto39
        objeto = new Objeto();
        objeto.Codigo = 39;
        objeto.Nombre = "Esposas";
        objeto.SetValor(2);
        objeto.SetPeso(6);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto39
        #region CrearObjeto40
        objeto = new Objeto();
        objeto.Codigo = 40;
        objeto.Nombre = "Estuche para mapa o pergamino";
        objeto.SetValor(1);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto40
        #region CrearObjeto41
        objeto = new Objeto();
        objeto.Codigo = 41;
        objeto.Nombre = "Estuche para virotes de ballesta";
        objeto.SetValor(1);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto41
        #region CrearObjeto42
        objeto = new Objeto();
        objeto.Codigo = 42;
        objeto.Nombre = "Frasco o jarra";
        objeto.SetValor(2);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PC;
        objectos.Add(objeto);
        #endregion CrearObjeto42
        #region CrearObjeto43
        objeto = new Objeto();
        objeto.Codigo = 43;
        objeto.Nombre = "Fuego de alquimista";
        objeto.SetValor(50);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto43
        #region CrearObjeto44
        objeto = new Objeto();
        objeto.Codigo = 44;
        objeto.Nombre = "Garfio de escalada";
        objeto.SetValor(2);
        objeto.SetPeso(4);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto44
        #region CrearObjeto45
        objeto = new Objeto();
        objeto.Codigo = 45;
        objeto.Nombre = "Jabon";
        objeto.SetValor(2);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PC;
        objectos.Add(objeto);
        #endregion CrearObjeto45
        #region CrearObjeto46
        objeto = new Objeto();
        objeto.Codigo = 46;
        objeto.Nombre = "Jarro o cantaro";
        objeto.SetValor(2);
        objeto.SetPeso(4);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PC;
        objectos.Add(objeto);
        #endregion CrearObjeto46
        #region CrearObjeto47
        objeto = new Objeto();
        objeto.Codigo = 47;
        objeto.Nombre = "Lacre";
        objeto.SetValor(5);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion CrearObjeto47
        #region CrearObjeto48
        objeto = new Objeto();
        objeto.Codigo = 48;
        objeto.Nombre = "Lampara";
        objeto.SetValor(5);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion CrearObjeto48
        #region CrearObjeto49
        objeto = new Objeto();
        objeto.Codigo = 49;
        objeto.Nombre = "Libro";
        objeto.SetValor(25);
        objeto.SetPeso(5);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto49
        #region CrearObjeto50
        objeto = new Objeto();
        objeto.Codigo = 50;
        objeto.Nombre = "Libro de conjuros";
        objeto.SetValor(50);
        objeto.SetPeso(3);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion 
        #region CrearObjeto51
        objeto = new Objeto();
        objeto.Codigo = 51;
        objeto.Nombre = "Linterna de ojo de buey";
        objeto.SetValor(10);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto51
        #region CrearObjeto52
        objeto = new Objeto();
        objeto.Codigo = 52;
        objeto.Nombre = "Linterna sorda";
        objeto.SetValor(5);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto52
        #region CrearObjeto53
        objeto = new Objeto();
        objeto.Codigo = 53;
        objeto.Nombre = "Lupa";
        objeto.SetValor(100);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto52
        #region CrearObjeto54
        objeto = new Objeto();
        objeto.Codigo = 54;
        objeto.Nombre = "Manta";
        objeto.SetValor(5);
        objeto.SetPeso(3);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion CrearObjeto54
        #region CrearObjeto55
        objeto = new Objeto();
        objeto.Codigo = 55;
        objeto.Nombre = "Martillo";
        objeto.SetValor(1);
        objeto.SetPeso(3);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto55
        #region CrearObjeto56
        objeto = new Objeto();
        objeto.Codigo = 56;
        objeto.Nombre = "Mazo";
        objeto.SetValor(2);
        objeto.SetPeso(10);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto56
        #region CrearObjeto57
        objeto = new Objeto();
        objeto.Codigo = 57;
        objeto.Nombre = "Mochila";
        objeto.SetValor(2);
        objeto.SetPeso(5);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto57
        #region CrearObjeto58
        objeto = new Objeto();
        objeto.Codigo = 58;
        objeto.Nombre = "Balas de honda";
        objeto.SetValor(4);
        objeto.SetPeso(1.5f);
        objeto.Tipo = E_TipoObjeto.Municion;
        objeto.SetCantidad(20);
        objeto.TipoValor = E_Monedas.PC;
        objectos.Add(objeto);
        #endregion CrearObjeto58
        #region CrearObjeto59
        objeto = new Objeto();
        objeto.Codigo = 59;
        objeto.Nombre = "Dardos de cerbatana";
        objeto.SetValor(1);
        objeto.SetPeso(1);
        objeto.Tipo = E_TipoObjeto.Municion;
        objeto.SetCantidad(50);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto59
        #region CrearObjeto60
        objeto = new Objeto();
        objeto.Codigo = 60;
        objeto.Nombre = "Flechas";
        objeto.SetValor(1);
        objeto.SetPeso(1);
        objeto.Tipo = E_TipoObjeto.Municion;
        objeto.SetCantidad(20);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto60
        #region CrearObjeto61
        objeto = new Objeto();
        objeto.Codigo = 61;
        objeto.Nombre = "Virotes de ballesta";
        objeto.SetValor(1);
        objeto.SetPeso(1.5f);
        objeto.Tipo = E_TipoObjeto.Municion;
        objeto.SetCantidad(20);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto61
        #region CrearObjeto62
        objeto = new Objeto();
        objeto.Codigo = 62;
        objeto.Nombre = "Olla de hierro";
        objeto.SetValor(2);
        objeto.SetPeso(10);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto62
        #region CrearObjeto63
        objeto = new Objeto();
        objeto.Codigo = 63;
        objeto.Nombre = "Pala";
        objeto.SetValor(2);
        objeto.SetPeso(5);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto63
        #region CrearObjeto64
        objeto = new Objeto();
        objeto.Codigo = 64;
        objeto.Nombre = "Palanca";
        objeto.SetValor(2);
        objeto.SetPeso(5);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto64
        #region CrearObjeto65
        objeto = new Objeto();
        objeto.Codigo = 65;
        objeto.Nombre = "Papel";
        objeto.SetValor(2);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion CrearObjeto65
        #region CrearObjeto66
        objeto = new Objeto();
        objeto.Codigo = 66;
        objeto.Nombre = "Perfume";
        objeto.SetValor(5);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto66
        #region CrearObjeto67
        objeto = new Objeto();
        objeto.Codigo = 67;
        objeto.Nombre = "Pergamino";
        objeto.SetValor(1);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion CrearObjeto67
        #region CrearObjeto68
        objeto = new Objeto();
        objeto.Codigo = 68;
        objeto.Nombre = "Petate";
        objeto.SetValor(1);
        objeto.SetPeso(7);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto68
        #region CrearObjeto69
        objeto = new Objeto();
        objeto.Codigo = 69;
        objeto.Nombre = "Pico de minero";
        objeto.SetValor(2);
        objeto.SetPeso(10);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto69
        #region CrearObjeto70
        objeto = new Objeto();
        objeto.Codigo = 70;
        objeto.Nombre = "Piedra de afilar";
        objeto.SetValor(1);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PC;
        objectos.Add(objeto);
        #endregion CrearObjeto70
        #region CrearObjeto71
        objeto = new Objeto();
        objeto.Codigo = 71;
        objeto.Nombre = "Pinchos de hierro";
        objeto.SetValor(1);
        objeto.SetPeso(5);
        objeto.SetCantidad(10);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto71
        #region CrearObjeto72
        objeto = new Objeto();
        objeto.Codigo = 72;
        objeto.Nombre = "Piton";
        objeto.SetValor(5);
        objeto.SetPeso(0.25f);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PC;
        objectos.Add(objeto);
        #endregion CrearObjeto72
        #region CrearObjeto73
        objeto = new Objeto();
        objeto.Codigo = 73;
        objeto.Nombre = "Pluma";
        objeto.SetValor(2);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PC;
        objectos.Add(objeto);
        #endregion CrearObjeto73
        #region CrearObjeto74
        objeto = new Objeto();
        objeto.Codigo = 74;
        objeto.Nombre = "Pocion de curacion";
        objeto.SetValor(50);
        objeto.SetPeso(0.5f);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto74
        #region CrearObjeto75
        objeto = new Objeto();
        objeto.Codigo = 75;
        objeto.Nombre = "Polipasto";
        objeto.SetValor(1);
        objeto.SetPeso(5);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto75
        #region CrearObjeto76
        objeto = new Objeto();
        objeto.Codigo = 76;
        objeto.Nombre = "Racion";
        objeto.SetValor(5);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion CrearObjeto76
        #region CrearObjeto77
        objeto = new Objeto();
        objeto.Codigo = 77;
        objeto.Nombre = "Reloj";
        objeto.SetValor(25);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto77
        #region CrearObjeto78
        objeto = new Objeto();
        objeto.Codigo = 78;
        objeto.Nombre = "Ropas comunes";
        objeto.SetValor(5);
        objeto.SetPeso(3);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto78
        #region CrearObjeto79
        objeto = new Objeto();
        objeto.Codigo = 79;
        objeto.Nombre = "Ropas de calidad";
        objeto.SetValor(15);
        objeto.SetPeso(6);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto79
        #region CrearObjeto80
        objeto = new Objeto();
        objeto.Codigo = 80;
        objeto.Nombre = "Ropas de viaje";
        objeto.SetValor(2);
        objeto.SetPeso(4);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto80
        #region CrearObjeto81
        objeto = new Objeto();
        objeto.Codigo = 81;
        objeto.Nombre = "Ropas, disfraz";
        objeto.SetValor(5);
        objeto.SetPeso(4);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto81
        #region CrearObjeto82
        objeto = new Objeto();
        objeto.Codigo = 82;
        objeto.Nombre = "Saco";
        objeto.SetValor(1);
        objeto.SetPeso(0.5f);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PC;
        objectos.Add(objeto);
        #endregion CrearObjeto82
        #region CrearObjeto83
        objeto = new Objeto();
        objeto.Codigo = 83;
        objeto.Nombre = "Saquito de componentes";
        objeto.SetValor(25);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto83
        #region CrearObjeto84
        objeto = new Objeto();
        objeto.Codigo = 84;
        objeto.Nombre = "Saquito de componentes";
        objeto.SetValor(25);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto84
        #region CrearObjeto85
        objeto = new Objeto();
        objeto.Codigo = 85;
        objeto.Nombre = "Silbato de supervivencia";
        objeto.SetValor(5);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PC;
        objectos.Add(objeto);
        #endregion CrearObjeto85
        #region CrearObjeto86
        objeto = new Objeto();
        objeto.Codigo = 86;
        objeto.Nombre = "Amuleto";
        objeto.Tipo = E_TipoObjeto.Simbolos_Sagrados;
        objeto.SetValor(5);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto86
        #region CrearObjeto87
        objeto = new Objeto();
        objeto.Codigo = 87;
        objeto.Nombre = "Emblema";
        objeto.Tipo = E_TipoObjeto.Simbolos_Sagrados;
        objeto.SetValor(5);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto87
        #region CrearObjeto88
        objeto = new Objeto();
        objeto.Codigo = 88;
        objeto.Tipo = E_TipoObjeto.Simbolos_Sagrados;
        objeto.Nombre = "Relicario";
        objeto.SetValor(5);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto88
        #region CrearObjeto89
        objeto = new Objeto();
        objeto.Codigo = 89;
        objeto.Nombre = "Tienda para dos personas";
        objeto.SetValor(2);
        objeto.SetPeso(20);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto89
        #region CrearObjeto90
        objeto = new Objeto();
        objeto.Codigo = 90;
        objeto.Nombre = "Tinta. botella de 1 onza";
        objeto.SetValor(10);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto90
        #region CrearObjeto91
        objeto = new Objeto();
        objeto.Codigo = 91;
        objeto.Nombre = "Tiza (1 trozo)";
        objeto.SetValor(1);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PC;
        objectos.Add(objeto);
        #endregion CrearObjeto91
        #region CrearObjeto92
        objeto = new Objeto();
        objeto.Codigo = 92;
        objeto.Nombre = "Trampa para cazar";
        objeto.SetValor(5);
        objeto.SetPeso(25);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto92
        #region CrearObjeto93
        objeto = new Objeto();
        objeto.Codigo = 93;
        objeto.Nombre = "Tunica";
        objeto.SetValor(1);
        objeto.SetPeso(4);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto93
        #region CrearObjeto94
        objeto = new Objeto();
        objeto.Codigo = 94;
        objeto.Nombre = "Utensilios de cocina";
        objeto.SetValor(2);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion CrearObjeto94
        #region CrearObjeto95
        objeto = new Objeto();
        objeto.Codigo = 95;
        objeto.Nombre = "Utiles de escalada";
        objeto.SetValor(25);
        objeto.SetPeso(12);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto95
        #region CrearObjeto96
        objeto = new Objeto();
        objeto.Codigo = 96;
        objeto.Nombre = "Utiles de sanador";
        objeto.SetValor(5);
        objeto.SetPeso(3);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto96
        #region CrearObjeto97
        objeto = new Objeto();
        objeto.Codigo = 97;
        objeto.Nombre = "Vara (10)";
        objeto.SetValor(5);
        objeto.SetPeso(7);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto97
        #region CrearObjeto98
        objeto = new Objeto();
        objeto.Codigo = 98;
        objeto.Nombre = "Vela";
        objeto.SetValor(1);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PC;
        objectos.Add(objeto);
        #endregion CrearObjeto98
        #region CrearObjeto99
        objeto = new Objeto();
        objeto.Codigo = 99;
        objeto.Nombre = "Veneno basico (vial)";
        objeto.SetValor(100);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto99
        #region CrearObjeto100
        objeto = new Objeto();
        objeto.Codigo = 100;
        objeto.Nombre = "Vial";
        objeto.SetValor(1);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto100
        #region CrearObjeto101
        objeto = new Objeto();
        objeto.Codigo = 101;
        objeto.Nombre = "Yesquero";
        objeto.SetValor(5);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion CrearObjeto101


        #endregion ObjetosCreados
        #region ArmasCreadas
        #region Arma1
        arma = new Arma();
        arma.Codigo = 102;
        arma.Nombre = "Baston";
        arma.Tipo = E_TipoObjeto.ARMA_SIMPLE;
        arma.SetValor(2);
        arma.SetPeso(4);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PP;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D6;
        arma.A�adirPropiedad(E_Propiedades.CONTUNDENTE);
        arma.A�adirPropiedad(E_Propiedades.VERSATIL);
        arma.CantidadSegundoDa�o = 1;
        arma.TipoDadoSegundoDa�o = E_TiposDados.D8;
        objectos.Add(arma);
        #endregion 
        #region Arma2
        arma = new Arma();
        arma.Codigo = 103;
        arma.Nombre = "Daga";
        arma.Tipo = E_TipoObjeto.ARMA_SIMPLE;
        arma.SetValor(2);
        arma.SetPeso(4);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D4;
        arma.A�adirPropiedad(E_Propiedades.CORTANTE);
        arma.A�adirPropiedad(E_Propiedades.ARROJADIZA);
        arma.A�adirPropiedad(E_Propiedades.LIGERA);
        arma.A�adirPropiedad(E_Propiedades.SUTIL);
        arma.SetAlcance(20, 60);
        objectos.Add(arma);
        #endregion Arma2
        #region Arma3
        arma = new Arma();
        arma.Codigo = 104;
        arma.Nombre = "Garrote";
        arma.Tipo = E_TipoObjeto.ARMA_SIMPLE;
        arma.SetValor(1);
        arma.SetPeso(2);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PP;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D4;
        arma.A�adirPropiedad(E_Propiedades.CONTUNDENTE);
        arma.A�adirPropiedad(E_Propiedades.LIGERA);
        objectos.Add(arma);
        #endregion Arma3
        #region Arma4
        arma = new Arma();
        arma.Codigo = 105;
        arma.Nombre = "Garrote Grande";
        arma.Tipo = E_TipoObjeto.ARMA_SIMPLE;
        arma.SetValor(2);
        arma.SetPeso(10);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PP;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D8;
        arma.A�adirPropiedad(E_Propiedades.CONTUNDENTE);
        arma.A�adirPropiedad(E_Propiedades.A_DOS_MANOS);
        objectos.Add(arma);
        #endregion Arma4
        #region Arma5
        arma = new Arma();
        arma.Codigo = 106;
        arma.Nombre = "Hacha de mano";
        arma.Tipo = E_TipoObjeto.ARMA_SIMPLE;
        arma.SetValor(5);
        arma.SetPeso(2);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D6;
        arma.A�adirPropiedad(E_Propiedades.CORTANTE);
        arma.A�adirPropiedad(E_Propiedades.ARROJADIZA);
        arma.A�adirPropiedad(E_Propiedades.ALCANCE);
        arma.A�adirPropiedad(E_Propiedades.LIGERA);
        arma.SetAlcance(20, 60);
        objectos.Add(arma);
        #endregion Arma5
        #region Arma6
        arma = new Arma();
        arma.Codigo = 107;
        arma.Nombre = "Hoz";
        arma.Tipo = E_TipoObjeto.ARMA_SIMPLE;
        arma.SetValor(1);
        arma.SetPeso(2);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D4;
        arma.A�adirPropiedad(E_Propiedades.CORTANTE);
        arma.A�adirPropiedad(E_Propiedades.LIGERA);
        objectos.Add(arma);
        #endregion Arma6
        #region Arma7
        arma = new Arma();
        arma.Codigo = 108;
        arma.Nombre = "Jabalina";
        arma.Tipo = E_TipoObjeto.ARMA_SIMPLE;
        arma.SetValor(5);
        arma.SetPeso(2);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PP;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D6;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        arma.A�adirPropiedad(E_Propiedades.ARROJADIZA);
        arma.A�adirPropiedad(E_Propiedades.ALCANCE);
        arma.SetAlcance(30, 120);
        objectos.Add(arma);
        #endregion Arma7
        #region Arma8
        arma = new Arma();
        arma.Codigo = 109;
        arma.Nombre = "Lanza";
        arma.Tipo = E_TipoObjeto.ARMA_SIMPLE;
        arma.SetValor(1);
        arma.SetPeso(3);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D6;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        arma.A�adirPropiedad(E_Propiedades.ARROJADIZA);
        arma.A�adirPropiedad(E_Propiedades.ALCANCE);
        arma.SetAlcance(20, 60);
        arma.A�adirPropiedad(E_Propiedades.VERSATIL);
        arma.CantidadSegundoDa�o = 1;
        arma.TipoDadoSegundoDa�o = E_TiposDados.D8;
        objectos.Add(arma);
        #endregion Arma8
        #region Arma9
        arma = new Arma();
        arma.Codigo = 110;
        arma.Nombre = "Martillo ligero";
        arma.Tipo = E_TipoObjeto.ARMA_SIMPLE;
        arma.SetValor(2);
        arma.SetPeso(2);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D4;
        arma.A�adirPropiedad(E_Propiedades.CONTUNDENTE);
        arma.A�adirPropiedad(E_Propiedades.ARROJADIZA);
        arma.A�adirPropiedad(E_Propiedades.ALCANCE);
        arma.SetAlcance(20, 60);
        arma.A�adirPropiedad(E_Propiedades.LIGERA);
        objectos.Add(arma);
        #endregion Arma9
        #region Arma10
        arma = new Arma();
        arma.Codigo = 111;
        arma.Nombre = "Maza";
        arma.Tipo = E_TipoObjeto.ARMA_SIMPLE;
        arma.SetValor(5);
        arma.SetPeso(4);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D6;
        arma.A�adirPropiedad(E_Propiedades.CONTUNDENTE);
        objectos.Add(arma);
        #endregion Arma10
        #region Arma11
        arma = new Arma();
        arma.Codigo = 112;
        arma.Nombre = "Arco corto";
        arma.Tipo = E_TipoObjeto.ARMA_A_DISTANCIA_SIMPLE;
        arma.SetValor(25);
        arma.SetPeso(2);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D6;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        arma.A�adirPropiedad(E_Propiedades.MUNICION);
        arma.A�adirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.A�adirPropiedad(E_Propiedades.ALCANCE);
        arma.SetAlcance(80,320);
        objectos.Add(arma);
        #endregion Arma11
        #region Arma12
        arma = new Arma();
        arma.Codigo = 113;
        arma.Nombre = "Ballesta ligera";
        arma.Tipo = E_TipoObjeto.ARMA_A_DISTANCIA_SIMPLE;
        arma.SetValor(25);
        arma.SetPeso(5);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D8;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        arma.A�adirPropiedad(E_Propiedades.MUNICION);
        arma.A�adirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.A�adirPropiedad(E_Propiedades.ALCANCE);
        arma.A�adirPropiedad(E_Propiedades.RECARGA);
        arma.SetAlcance(80, 320);
        objectos.Add(arma);
        #endregion Arma12
        #region Arma13
        arma = new Arma();
        arma.Codigo = 114;
        arma.Nombre = "Dardo";
        arma.Tipo = E_TipoObjeto.ARMA_A_DISTANCIA_SIMPLE;
        arma.SetValor(5);
        arma.SetPeso(0.25f);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PC;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D4;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        arma.A�adirPropiedad(E_Propiedades.SUTIL);
        arma.A�adirPropiedad(E_Propiedades.ARROJADIZA);
        arma.A�adirPropiedad(E_Propiedades.ALCANCE);
        arma.SetAlcance(20, 60);
        objectos.Add(arma);
        #endregion Arma13
        #region Arma14
        arma = new Arma();
        arma.Codigo = 115;
        arma.Nombre = "Honda";
        arma.Tipo = E_TipoObjeto.ARMA_A_DISTANCIA_SIMPLE;
        arma.SetValor(1);
        arma.SetPeso(0);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PP;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D4;
        arma.A�adirPropiedad(E_Propiedades.CONTUNDENTE);
        arma.A�adirPropiedad(E_Propiedades.SUTIL);
        arma.A�adirPropiedad(E_Propiedades.MUNICION);
        arma.A�adirPropiedad(E_Propiedades.ALCANCE);
        arma.SetAlcance(20, 60);
        objectos.Add(arma);
        #endregion Arma14
        #region Arma15
        arma = new Arma();
        arma.Codigo = 116;
        arma.Nombre = "Alabarda";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(20);
        arma.SetPeso(6);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D10;
        arma.A�adirPropiedad(E_Propiedades.CORTANTE);
        arma.A�adirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.A�adirPropiedad(E_Propiedades.GRAN_ALCANCE);
        arma.A�adirPropiedad(E_Propiedades.PESADA);
        objectos.Add(arma);
        #endregion Arma15
        #region Arma16
        arma = new Arma();
        arma.Codigo = 117;
        arma.Nombre = "Cimitarra";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(25);
        arma.SetPeso(3);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D6;
        arma.A�adirPropiedad(E_Propiedades.CORTANTE);
        arma.A�adirPropiedad(E_Propiedades.LIGERA);
        arma.A�adirPropiedad(E_Propiedades.SUTIL);
        objectos.Add(arma);
        #endregion Arma16
        #region Arma17
        arma = new Arma();
        arma.Codigo = 118;
        arma.Nombre = "Espada corta";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(10);
        arma.SetPeso(2);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D6;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        arma.A�adirPropiedad(E_Propiedades.LIGERA);
        arma.A�adirPropiedad(E_Propiedades.SUTIL);
        objectos.Add(arma);
        #endregion Arma17
        #region Arma18
        arma = new Arma();
        arma.Codigo = 119;
        arma.Nombre = "Espada Larga";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(15);
        arma.SetPeso(3);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D8;
        arma.A�adirPropiedad(E_Propiedades.CORTANTE);
        arma.A�adirPropiedad(E_Propiedades.VERSATIL);
        arma.CantidadSegundoDa�o = 1;
        arma.TipoDadoSegundoDa�o= E_TiposDados.D10;
        objectos.Add(arma);
        #endregion Arma18
        #region Arma19
        arma = new Arma();
        arma.Codigo = 120;
        arma.Nombre = "Espadon";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(50);
        arma.SetPeso(6);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 2;
        arma.TipoDadoDa�o = E_TiposDados.D8;
        arma.A�adirPropiedad(E_Propiedades.CORTANTE);
        arma.A�adirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.A�adirPropiedad(E_Propiedades.PESADA);
        objectos.Add(arma);
        #endregion Arma19
        #region Arma20
        arma = new Arma();
        arma.Codigo = 121;
        arma.Nombre = "Estoque";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(25);
        arma.SetPeso(2);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D8;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        arma.A�adirPropiedad(E_Propiedades.SUTIL);
        objectos.Add(arma);
        #endregion Arma20
        #region Arma21
        arma = new Arma();
        arma.Codigo = 122;
        arma.Nombre = "Flagelo";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(10);
        arma.SetPeso(2);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D8;
        arma.A�adirPropiedad(E_Propiedades.CONTUNDENTE);
        objectos.Add(arma);
        #endregion Arma21
        #region Arma22
        arma = new Arma();
        arma.Codigo = 123;
        arma.Nombre = "Guja";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(20);
        arma.SetPeso(6);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D10;
        arma.A�adirPropiedad(E_Propiedades.CORTANTE);
        arma.A�adirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.A�adirPropiedad(E_Propiedades.GRAN_ALCANCE);
        arma.A�adirPropiedad(E_Propiedades.PESADA);
        objectos.Add(arma);
        #endregion Arma22
        #region Arma23
        arma = new Arma();
        arma.Codigo = 124;
        arma.Nombre = "Hacha a dos manos";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(30);
        arma.SetPeso(7);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D12;
        arma.A�adirPropiedad(E_Propiedades.CORTANTE);
        arma.A�adirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.A�adirPropiedad(E_Propiedades.GRAN_ALCANCE);
        arma.A�adirPropiedad(E_Propiedades.PESADA);
        objectos.Add(arma);
        #endregion Arma23
        #region Arma24
        arma = new Arma();
        arma.Codigo = 125;
        arma.Nombre = "Hacha de guerra";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(10);
        arma.SetPeso(4);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D8;
        arma.A�adirPropiedad(E_Propiedades.CORTANTE);
        arma.A�adirPropiedad(E_Propiedades.VERSATIL);
        arma.CantidadSegundoDa�o = 1;
        arma.TipoDadoSegundoDa�o= E_TiposDados.D10;
        objectos.Add(arma);
        #endregion Arma24
        #region Arma25
        arma = new Arma();
        arma.Codigo = 126;
        arma.Nombre = "Lanza de caballeria";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(10);
        arma.SetPeso(6);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D12;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        arma.A�adirPropiedad(E_Propiedades.GRAN_ALCANCE);
        arma.A�adirPropiedad(E_Propiedades.ESPECIAL);
        objectos.Add(arma);
        #endregion Arma25
        #region Arma26
        arma = new Arma();
        arma.Codigo = 127;
        arma.Nombre = "Latigo";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(2);
        arma.SetPeso(3);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D4;
        arma.A�adirPropiedad(E_Propiedades.CORTANTE);
        arma.A�adirPropiedad(E_Propiedades.GRAN_ALCANCE);
        arma.A�adirPropiedad(E_Propiedades.SUTIL);
        objectos.Add(arma);
        #endregion Arma26
        #region Arma27
        arma = new Arma();
        arma.Codigo = 128;
        arma.Nombre = "Lucero del alba";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(15);
        arma.SetPeso(4);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D8;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        objectos.Add(arma);
        #endregion Arma27
        #region Arma28
        arma = new Arma();
        arma.Codigo = 129;
        arma.Nombre = "Martillo de guerra";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(15);
        arma.SetPeso(2);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D8;
        arma.A�adirPropiedad(E_Propiedades.CONTUNDENTE);
        arma.A�adirPropiedad(E_Propiedades.VERSATIL);
        arma.CantidadSegundoDa�o = 1;
        arma.TipoDadoSegundoDa�o = E_TiposDados.D10;
        objectos.Add(arma);
        #endregion Arma28
        #region Arma29
        arma = new Arma();
        arma.Codigo = 130;
        arma.Nombre = "Maza a dos manos";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(15);
        arma.SetPeso(10);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 2;
        arma.TipoDadoDa�o = E_TiposDados.D6;
        arma.A�adirPropiedad(E_Propiedades.CONTUNDENTE);
        arma.A�adirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.A�adirPropiedad(E_Propiedades.PESADA);
        objectos.Add(arma);
        #endregion Arma29
        #region Arma30
        arma = new Arma();
        arma.Codigo = 131;
        arma.Nombre = "Pica";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(5);
        arma.SetPeso(18);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D10;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        arma.A�adirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.A�adirPropiedad(E_Propiedades.GRAN_ALCANCE);
        arma.A�adirPropiedad(E_Propiedades.PESADA);
        objectos.Add(arma);
        #endregion Arma30
        #region Arma31
        arma = new Arma();
        arma.Codigo = 132;
        arma.Nombre = "Pico de guerra";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(5);
        arma.SetPeso(2);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D8;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        objectos.Add(arma);
        #endregion Arma31
        #region Arma32
        arma = new Arma();
        arma.Codigo = 133;
        arma.Nombre = "Tridente";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(5);
        arma.SetPeso(4);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D6;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        arma.A�adirPropiedad(E_Propiedades.ARROJADIZA);
        arma.A�adirPropiedad(E_Propiedades.ALCANCE);
        arma.SetAlcance(20, 60);
        arma.A�adirPropiedad(E_Propiedades.VERSATIL);
        arma.CantidadSegundoDa�o = 1;
        arma.TipoDadoSegundoDa�o = E_TiposDados.D8;
        objectos.Add(arma);
        #endregion Arma32
        #region Arma33
        arma = new Arma();
        arma.Codigo = 134;
        arma.Nombre = "Arco largo";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(50);
        arma.SetPeso(2);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D8;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        arma.A�adirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.A�adirPropiedad(E_Propiedades.MUNICION);
        arma.A�adirPropiedad(E_Propiedades.PESADA);
        arma.A�adirPropiedad(E_Propiedades.ALCANCE);
        arma.SetAlcance(150,600);
        objectos.Add(arma);
        #endregion Arma33
        #region Arma34
        arma = new Arma();
        arma.Codigo = 135;
        arma.Nombre = "Ballesta de mano";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(75);
        arma.SetPeso(3);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D6;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        arma.A�adirPropiedad(E_Propiedades.RECARGA);
        arma.A�adirPropiedad(E_Propiedades.MUNICION);
        arma.A�adirPropiedad(E_Propiedades.LIGERA);
        arma.A�adirPropiedad(E_Propiedades.ALCANCE);
        arma.SetAlcance(30, 120);
        objectos.Add(arma);
        #endregion Arma34
        #region Arma35
        arma = new Arma();
        arma.Codigo = 136;
        arma.Nombre = "Ballesta pesada";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(75);
        arma.SetPeso(3);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D10;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        arma.A�adirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.A�adirPropiedad(E_Propiedades.RECARGA);
        arma.A�adirPropiedad(E_Propiedades.MUNICION);
        arma.A�adirPropiedad(E_Propiedades.PESADA);
        arma.A�adirPropiedad(E_Propiedades.ALCANCE);
        arma.SetAlcance(100, 400);
        objectos.Add(arma);
        #endregion Arma35
        #region Arma36
        arma = new Arma();
        arma.Codigo = 137;
        arma.Nombre = "Cerbatana";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(10);
        arma.SetPeso(1);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 1;
        arma.TipoDadoDa�o = E_TiposDados.D4;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        arma.A�adirPropiedad(E_Propiedades.RECARGA);
        arma.A�adirPropiedad(E_Propiedades.MUNICION);
        arma.A�adirPropiedad(E_Propiedades.ALCANCE);
        arma.SetAlcance(25, 100);
        objectos.Add(arma);
        #endregion Arma36
        #region Arma37
        arma = new Arma();
        arma.Codigo = 138;
        arma.Nombre = "Red";
        arma.Tipo = E_TipoObjeto.ARMA_MARCIAL;
        arma.SetValor(1);
        arma.SetPeso(3);
        arma.SetCantidad(1);
        arma.TipoValor = E_Monedas.PO;
        arma.CantidadDa�o = 0;
        arma.TipoDadoDa�o = E_TiposDados.D4;
        arma.A�adirPropiedad(E_Propiedades.PERFORANTE);
        arma.A�adirPropiedad(E_Propiedades.ARROJADIZA);
        arma.A�adirPropiedad(E_Propiedades.ESPECIAL);
        arma.A�adirPropiedad(E_Propiedades.ALCANCE);
        arma.SetAlcance(5, 15);
        objectos.Add(arma);
        #endregion Arma37
        #endregion ArmasCreadas
        #region ArmadurasCreadas
        #region Armadura1
        armadura = new Armadura();
        armadura.Codigo = 139;
        armadura.Nombre = "Acolchada";
        armadura.Tipo = E_TipoObjeto.ARMADURA_LIGERA;
        armadura.SetValor(5);
        armadura.TipoValor = E_Monedas.PO;
        armadura.SetPeso(8);
        armadura.SetCantidad(1);
        armadura.SetValorCABase(11);
        armadura.SetModificadorDestreza(true);
        armadura.SetRequisitoFuerza(0);
        armadura.SetDesventajaSigilo(true);
        objectos.Add(armadura);

        #endregion Armadura1
        #region Armadura2
        armadura = new Armadura();
        armadura.Codigo = 140;
        armadura.Nombre = "Cuero";
        armadura.Tipo = E_TipoObjeto.ARMADURA_LIGERA;
        armadura.SetValor(10);
        armadura.TipoValor = E_Monedas.PO;
        armadura.SetPeso(10);
        armadura.SetCantidad(1);
        armadura.SetValorCABase(11);
        armadura.SetModificadorDestreza(true);
        armadura.SetRequisitoFuerza(0);
        armadura.SetDesventajaSigilo(false);
        objectos.Add(armadura);

        #endregion Armadura2
        #region Armadura3
        armadura = new Armadura();
        armadura.Codigo = 141;
        armadura.Nombre = "Cuero tachonado";
        armadura.Tipo = E_TipoObjeto.ARMADURA_LIGERA;
        armadura.SetValor(45);
        armadura.TipoValor = E_Monedas.PO;
        armadura.SetPeso(13);
        armadura.SetCantidad(1);
        armadura.SetValorCABase(12);
        armadura.SetModificadorDestreza(true);
        armadura.SetRequisitoFuerza(0);
        armadura.SetDesventajaSigilo(false);
        objectos.Add(armadura);

        #endregion Armadura3
        #region Armadura4
        armadura = new Armadura();
        armadura.Codigo = 142;
        armadura.Nombre = "Camisa de malla";
        armadura.Tipo = E_TipoObjeto.ARMADURA_MEDIA;
        armadura.SetValor(50);
        armadura.TipoValor = E_Monedas.PO;
        armadura.SetPeso(20);
        armadura.SetCantidad(1);
        armadura.SetValorCABase(13);
        armadura.SetModificadorDestreza(true);
        armadura.SetMaximoModificadorDestreza(2);
        armadura.SetRequisitoFuerza(0);
        armadura.SetDesventajaSigilo(false);
        objectos.Add(armadura);

        #endregion Armadura4
        #region Armadura5
        armadura = new Armadura();
        armadura.Codigo = 143;
        armadura.Nombre = "Cota de escamas";
        armadura.Tipo = E_TipoObjeto.ARMADURA_MEDIA;
        armadura.SetValor(50);
        armadura.TipoValor = E_Monedas.PO;
        armadura.SetCantidad(1);
        armadura.SetValorCABase(14);
        armadura.SetModificadorDestreza(true);
        armadura.SetMaximoModificadorDestreza(2);
        armadura.SetRequisitoFuerza(0);
        armadura.SetDesventajaSigilo(true);
        armadura.SetPeso(45);
        objectos.Add(armadura);

        #endregion Armadura5
        #region Armadura6
        armadura = new Armadura();
        armadura.Codigo = 144;
        armadura.Nombre = "Coraza";
        armadura.Tipo = E_TipoObjeto.ARMADURA_MEDIA;
        armadura.SetValor(400);
        armadura.TipoValor = E_Monedas.PO;
        armadura.SetCantidad(1);
        armadura.SetValorCABase(14);
        armadura.SetModificadorDestreza(true);
        armadura.SetMaximoModificadorDestreza(2);
        armadura.SetRequisitoFuerza(0);
        armadura.SetDesventajaSigilo(false);
        armadura.SetPeso(20);
        objectos.Add(armadura);

        #endregion Armadura6
        #region Armadura8
        armadura = new Armadura();
        armadura.Codigo = 145;
        armadura.Nombre = "Media armadura";
        armadura.Tipo = E_TipoObjeto.ARMADURA_MEDIA;
        armadura.SetValor(750);
        armadura.TipoValor = E_Monedas.PO;
        armadura.SetCantidad(1);
        armadura.SetValorCABase(15);
        armadura.SetModificadorDestreza(true);
        armadura.SetMaximoModificadorDestreza(2);
        armadura.SetRequisitoFuerza(0);
        armadura.SetDesventajaSigilo(true);
        armadura.SetPeso(40);
        objectos.Add(armadura);

        #endregion Armadura8
        #region Armadura9
        armadura = new Armadura();
        armadura.Codigo = 146;
        armadura.Nombre = "Pieles";
        armadura.Tipo = E_TipoObjeto.ARMADURA_MEDIA;
        armadura.SetValor(10);
        armadura.TipoValor = E_Monedas.PO;
        armadura.SetCantidad(1);
        armadura.SetValorCABase(12);
        armadura.SetModificadorDestreza(true);
        armadura.SetMaximoModificadorDestreza(2);
        armadura.SetRequisitoFuerza(0);
        armadura.SetDesventajaSigilo(false);
        armadura.SetPeso(12);
        objectos.Add(armadura);

        #endregion Armadura9
        #region Armadura10
        armadura = new Armadura();
        armadura.Codigo = 147;
        armadura.Nombre = "Armadura de bandas";
        armadura.Tipo = E_TipoObjeto.ARMADURA_PESADA;
        armadura.SetValor(200);
        armadura.TipoValor = E_Monedas.PO;
        armadura.SetCantidad(1);
        armadura.SetValorCABase(17);
        armadura.SetModificadorDestreza(false);
        armadura.SetMaximoModificadorDestreza(0);
        armadura.SetRequisitoFuerza(15);
        armadura.SetDesventajaSigilo(true);
        armadura.SetPeso(60);
        objectos.Add(armadura);

        #endregion Armadura10
        #region Armadura11
        armadura = new Armadura();
        armadura.Codigo = 148;
        armadura.Nombre = "Armadura de placas";
        armadura.Tipo = E_TipoObjeto.ARMADURA_PESADA;
        armadura.SetValor(1500);
        armadura.TipoValor = E_Monedas.PO;
        armadura.SetCantidad(1);
        armadura.SetValorCABase(18);
        armadura.SetModificadorDestreza(false);
        armadura.SetMaximoModificadorDestreza(0);
        armadura.SetRequisitoFuerza(15);
        armadura.SetDesventajaSigilo(true);
        armadura.SetPeso(65);
        objectos.Add(armadura);

        #endregion Armadura11
        #region Armadura12
        armadura = new Armadura();
        armadura.Codigo = 149;
        armadura.Nombre = "Cota guarnecida";
        armadura.Tipo = E_TipoObjeto.ARMADURA_PESADA;
        armadura.SetValor(30);
        armadura.TipoValor = E_Monedas.PO;
        armadura.SetCantidad(1);
        armadura.SetValorCABase(14);
        armadura.SetModificadorDestreza(false);
        armadura.SetMaximoModificadorDestreza(0);
        armadura.SetRequisitoFuerza(0);
        armadura.SetDesventajaSigilo(true);
        armadura.SetPeso(40);
        objectos.Add(armadura);

        #endregion Armadura12
        #region Armadura13
        armadura = new Armadura();
        armadura.Codigo = 150;
        armadura.Nombre = "Cota de malla";
        armadura.Tipo = E_TipoObjeto.ARMADURA_PESADA;
        armadura.SetValor(75);
        armadura.TipoValor = E_Monedas.PO;
        armadura.SetCantidad(1);
        armadura.SetValorCABase(16);
        armadura.SetModificadorDestreza(false);
        armadura.SetMaximoModificadorDestreza(0);
        armadura.SetRequisitoFuerza(13);
        armadura.SetDesventajaSigilo(true);
        armadura.SetPeso(55);
        objectos.Add(armadura);

        #endregion Armadura13
        #region Armadura14
        armadura = new Armadura();
        armadura.Codigo = 151;
        armadura.Nombre = "Escudo";
        armadura.Tipo = E_TipoObjeto.ESCUDO;
        armadura.SetValor(10);
        armadura.TipoValor = E_Monedas.PO;
        armadura.SetCantidad(1);
        armadura.SetValorCABase(2);
        armadura.SetModificadorDestreza(false);
        armadura.SetMaximoModificadorDestreza(0);
        armadura.SetRequisitoFuerza(0);
        armadura.SetDesventajaSigilo(false);
        armadura.SetPeso(6);
        objectos.Add(armadura);

        #endregion Armadura14
        #endregion ArmadurasCreadas
        #region Herramientas
        #region Herramienta1
        objeto = new Objeto();
        objeto.Codigo = 152;
        objeto.Nombre = "Herramientas de alba�il";
        objeto.SetValor(10);
        objeto.SetPeso(8);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta1
        #region Herramienta2
        objeto = new Objeto();
        objeto.Codigo = 153;
        objeto.Nombre = "Herramientas de alfarero";
        objeto.SetValor(10);
        objeto.SetPeso(3);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta2
        #region Herramienta3
        objeto = new Objeto();
        objeto.Codigo = 154;
        objeto.Nombre = "Herramientas de carpintero";
        objeto.SetValor(8);
        objeto.SetPeso(6);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta3
        #region Herramienta4
        objeto = new Objeto();
        objeto.Codigo = 155;
        objeto.Nombre = "Herramientas de cartografo";
        objeto.SetValor(15);
        objeto.SetPeso(6);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta4
        #region Herramienta5
        objeto = new Objeto();
        objeto.Codigo = 156;
        objeto.Nombre = "Herramientas de curtidor";
        objeto.SetValor(5);
        objeto.SetPeso(5);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta5
        #region Herramienta6
        objeto = new Objeto();
        objeto.Codigo = 157;
        objeto.Nombre = "Herramientas de ebanista";
        objeto.SetValor(1);
        objeto.SetPeso(5);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta6
        #region Herramienta7
        objeto = new Objeto();
        objeto.Codigo = 158;
        objeto.Nombre = "Herramientas de herrero";
        objeto.SetValor(20);
        objeto.SetPeso(8);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta7
        #region Herramienta8
        objeto = new Objeto();
        objeto.Codigo = 159;
        objeto.Nombre = "Herramientas de joyero";
        objeto.SetValor(25);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta8
        #region Herramienta9
        objeto = new Objeto();
        objeto.Codigo = 160;
        objeto.Nombre = "Herramientas de manitas";
        objeto.SetValor(50);
        objeto.SetPeso(10);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta9
        #region Herramienta10
        objeto = new Objeto();
        objeto.Codigo = 161;
        objeto.Nombre = "Herramientas de soplador de vidrio";
        objeto.SetValor(30);
        objeto.SetPeso(5);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta10
        #region Herramienta11
        objeto = new Objeto();
        objeto.Codigo = 162;
        objeto.Nombre = "Herramientas de tejedor";
        objeto.SetValor(1);
        objeto.SetPeso(5);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta11
        #region Herramienta12
        objeto = new Objeto();
        objeto.Codigo = 163;
        objeto.Nombre = "Herramientas de zapatero";
        objeto.SetValor(5);
        objeto.SetPeso(5);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta12
        #region Herramienta13
        objeto = new Objeto();
        objeto.Codigo = 164;
        objeto.Nombre = "Herramientas de alquimista";
        objeto.SetValor(50);
        objeto.SetPeso(8);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta13
        #region Herramienta14
        objeto = new Objeto();
        objeto.Codigo = 165;
        objeto.Nombre = "Herramientas de cal�grafo";
        objeto.SetValor(10);
        objeto.SetPeso(5);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta14
        #region Herramienta15
        objeto = new Objeto();
        objeto.Codigo = 166;
        objeto.Nombre = "Herramientas de cervecero";
        objeto.SetValor(20);
        objeto.SetPeso(9);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta15
        #region Herramienta16
        objeto = new Objeto();
        objeto.Codigo = 167;
        objeto.Nombre = "Herramientas de pintor";
        objeto.SetValor(10);
        objeto.SetPeso(5);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta16
        #region Herramienta17
        objeto = new Objeto();
        objeto.Codigo = 168;
        objeto.Nombre = "Utiles de cocinero";
        objeto.SetValor(1);
        objeto.SetPeso(8);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta17
        #region Herramienta18
        objeto = new Objeto();
        objeto.Codigo = 169;
        objeto.Nombre = "Herramientas de ladron";
        objeto.SetValor(25);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta18
        #region Herramienta19
        objeto = new Objeto();
        objeto.Codigo = 170;
        objeto.Nombre = "Herramientas de navegante";
        objeto.SetValor(25);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta19
        #region Herramienta20
        objeto = new Objeto();
        objeto.Codigo = 171;
        objeto.Nombre = "Chirimia";
        objeto.SetValor(2);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta20
        #region Herramienta21
        objeto = new Objeto();
        objeto.Codigo = 172;
        objeto.Nombre = "Cuerno";
        objeto.SetValor(3);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta21
        #region Herramienta22
        objeto = new Objeto();
        objeto.Codigo = 173;
        objeto.Nombre = "Dulc�mele";
        objeto.SetValor(25);
        objeto.SetPeso(10);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta22
        #region Herramienta23
        objeto = new Objeto();
        objeto.Codigo = 174;
        objeto.Nombre = "Flauta";
        objeto.SetValor(2);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta23
        #region Herramienta24
        objeto = new Objeto();
        objeto.Codigo = 175;
        objeto.Nombre = "Flauta de pan";
        objeto.SetValor(12);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta24
        #region Herramienta25
        objeto = new Objeto();
        objeto.Codigo = 176;
        objeto.Nombre = "Gaita";
        objeto.SetValor(30);
        objeto.SetPeso(6);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta25
        #region Herramienta26
        objeto = new Objeto();
        objeto.Codigo = 177;
        objeto.Nombre = "La�d";
        objeto.SetValor(35);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta26
        #region Herramienta27
        objeto = new Objeto();
        objeto.Codigo = 178;
        objeto.Nombre = "Lira";
        objeto.SetValor(30);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta27
        #region Herramienta28
        objeto = new Objeto();
        objeto.Codigo = 179;
        objeto.Nombre = "Tambor";
        objeto.SetValor(6);
        objeto.SetPeso(3);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta28
        #region Herramienta29
        objeto = new Objeto();
        objeto.Codigo = 180;
        objeto.Nombre = "Viola";
        objeto.SetValor(30);
        objeto.SetPeso(1);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta29
        #region Herramienta30
        objeto = new Objeto();
        objeto.Codigo = 181;
        objeto.Nombre = "Ajedrez Drag�n";
        objeto.SetValor(1);
        objeto.SetPeso(1.5f);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta30
        #region Herramienta31
        objeto = new Objeto();
        objeto.Codigo = 182;
        objeto.Nombre = "Apuesta de los tres dragones";
        objeto.SetValor(1);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta31
        #region Herramienta32
        objeto = new Objeto();
        objeto.Codigo = 183;
        objeto.Nombre = "Dados";
        objeto.SetValor(1);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion Herramienta32
        #region Herramienta33
        objeto = new Objeto();
        objeto.Codigo = 184;
        objeto.Nombre = "Naipes";
        objeto.SetValor(5);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion Herramienta33
        #region Herramienta34
        objeto = new Objeto();
        objeto.Codigo = 185;
        objeto.Nombre = "Naipes";
        objeto.SetValor(5);
        objeto.SetPeso(0);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PP;
        objectos.Add(objeto);
        #endregion Herramienta34
        #region Herramienta35
        objeto = new Objeto();
        objeto.Codigo = 186;
        objeto.Nombre = "Utiles de envenenador";
        objeto.SetValor(50);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta35
        #region Herramienta36
        objeto = new Objeto();
        objeto.Codigo = 187;
        objeto.Nombre = "Utiles de herborista";
        objeto.SetValor(5);
        objeto.SetPeso(3);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta36
        #region Herramienta37
        objeto = new Objeto();
        objeto.Codigo = 188;
        objeto.Nombre = "Utiles para disfrazarse";
        objeto.SetValor(25);
        objeto.SetPeso(3);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta37
        #region Herramienta38
        objeto = new Objeto();
        objeto.Codigo = 189;
        objeto.Nombre = "Utiles para falsificar";
        objeto.SetValor(15);
        objeto.SetPeso(5);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion Herramienta38
        #endregion Herramientas
        #region Paquetes
        #region PaqueteArtista
        paquete = new Paquete();
        paquete.Codigo = 190;
        paquete.Nombre = "Paquete de artista";
        paquete.SetValor(40);
        paquete.SetPeso(0);
        paquete.SetCantidad(1);
        paquete.TipoValor = E_Monedas.PO;
        paquete.Equipo.Add(BuscarObjeto(objectos,57));
        paquete.Equipo.Add(BuscarObjeto(objectos, 68));
        objeto = BuscarObjeto(objectos, 81);
        objeto.SetCantidad(2);
        paquete.Equipo.Add(objeto);
        objeto = BuscarObjeto(objectos, 98);//VELAS
        objeto.SetCantidad(5);
        paquete.Equipo.Add(objeto);
        objeto = BuscarObjeto(objectos, 76);
        objeto.SetCantidad(5);
        paquete.Equipo.Add(objeto);
        paquete.Equipo.Add(BuscarObjeto(objectos, 28));
        paquete.Equipo.Add(BuscarObjeto(objectos, 188));
        objectos.Add(paquete);
        #endregion PaqueteArtista
        #region PaqueteDiplomatico
        paquete = new Paquete();
        paquete.Codigo = 153;
        paquete.Nombre = "Paquete de diplomatico";
        paquete.SetValor(39);
        paquete.SetPeso(0);
        paquete.SetCantidad(1);
        paquete.TipoValor = E_Monedas.PO;
        paquete.Equipo.Add(BuscarObjeto(objectos, 33));
        objeto = BuscarObjeto(objectos, 33);
        objeto.SetCantidad(2);
        paquete.Equipo.Add(objeto);
        paquete.Equipo.Add(BuscarObjeto(objectos, 79));
        objeto = BuscarObjeto(objectos, 65);
        objeto.SetCantidad(5);
        paquete.Equipo.Add(objeto);
        paquete.Equipo.Add(BuscarObjeto(objectos, 66));
        paquete.Equipo.Add(BuscarObjeto(objectos, 73));
        paquete.Equipo.Add(BuscarObjeto(objectos, 90));
        paquete.Equipo.Add(BuscarObjeto(objectos, 4));
        paquete.Equipo.Add(BuscarObjeto(objectos, 47));
        paquete.Equipo.Add(BuscarObjeto(objectos, 45));
        objectos.Add(paquete);
        #endregion PaqueteDiplomatico
        #region PaqueteErudito
        paquete = new Paquete();
        paquete.Codigo = 191;
        paquete.Nombre = "Paquete de erudito";
        paquete.SetValor(40);
        paquete.SetPeso(0);
        paquete.SetCantidad(1);
        paquete.TipoValor = E_Monedas.PO;
        paquete.Equipo.Add(BuscarObjeto(objectos, 57));
        paquete.Equipo.Add(BuscarObjeto(objectos, 68));
        paquete.Equipo.Add(BuscarObjeto(objectos, 49));
        paquete.Equipo.Add(BuscarObjeto(objectos, 90));
        paquete.Equipo.Add(BuscarObjeto(objectos, 73));
        paquete.Equipo.Add(BuscarObjeto(objectos, 15));
        objeto = BuscarObjeto(objectos, 67);
        objeto.SetCantidad(10);
        paquete.Equipo.Add(objeto);

        objectos.Add(paquete);
        #endregion PaqueteErudito
        #region PaqueteExplorador
        paquete = new Paquete();
        paquete.Codigo = 192;
        paquete.Nombre = "Paquete de explorador";
        paquete.SetValor(40);
        paquete.SetPeso(0);
        paquete.SetCantidad(1);
        paquete.TipoValor = E_Monedas.PO;
        paquete.Equipo.Add(BuscarObjeto(objectos, 57));
        paquete.Equipo.Add(BuscarObjeto(objectos, 68));
        paquete.Equipo.Add(BuscarObjeto(objectos, 168));
        paquete.Equipo.Add(BuscarObjeto(objectos, 101));
        objeto = BuscarObjeto(objectos, 10);
        objeto.SetCantidad(10);
        paquete.Equipo.Add(objeto);
        objeto = BuscarObjeto(objectos, 76);
        objeto.SetCantidad(10);
        paquete.Equipo.Add(objeto);
        paquete.Equipo.Add(BuscarObjeto(objectos, 28));
        paquete.Equipo.Add(BuscarObjeto(objectos, 34));
        objectos.Add(paquete);

        #endregion PaqueteErudito
        #region PaqueteExploradorDeMazmorras
        paquete = new Paquete();
        paquete.Codigo = 193;
        paquete.Nombre = "Paquete de explorador de mazmorras";
        paquete.SetValor(10);
        paquete.SetPeso(0);
        paquete.SetCantidad(1);
        paquete.TipoValor = E_Monedas.PO;
        paquete.Equipo.Add(BuscarObjeto(objectos, 57));
        paquete.Equipo.Add(BuscarObjeto(objectos, 64));
        paquete.Equipo.Add(BuscarObjeto(objectos, 55));
        objeto = BuscarObjeto(objectos, 72);
        objeto.SetCantidad(10);
        paquete.Equipo.Add(objeto);
        objeto = BuscarObjeto(objectos, 10);
        objeto.SetCantidad(10);
        paquete.Equipo.Add(objeto);
        objeto = BuscarObjeto(objectos, 76);
        objeto.SetCantidad(10);
        paquete.Equipo.Add(objeto);
        paquete.Equipo.Add(BuscarObjeto(objectos, 28));
        paquete.Equipo.Add(BuscarObjeto(objectos, 34));
        objectos.Add(paquete);

        #endregion PaqueteExploradorDeMazmorras
        #region PaqueteLadron
        paquete = new Paquete();
        paquete.Codigo = 194;
        paquete.Nombre = "Paquete de ladr�n";
        paquete.SetValor(16);
        paquete.SetPeso(1);
        paquete.SetCantidad(1);
        paquete.TipoValor = E_Monedas.PO;
        paquete.Equipo.Add(BuscarObjeto(objectos, 57));
        objeto = BuscarObjeto(objectos, 14);
        objeto.SetCantidad(10);
        paquete.Equipo.Add(objeto);
        paquete.Equipo.Add(BuscarObjeto(objectos, 18));
        objeto = BuscarObjeto(objectos, 98);
        objeto.SetCantidad(5);
        paquete.Equipo.Add(objeto);
        paquete.Equipo.Add(BuscarObjeto(objectos, 64));
        paquete.Equipo.Add(BuscarObjeto(objectos, 55));
        objeto = BuscarObjeto(objectos, 72);
        objeto.SetCantidad(10);
        paquete.Equipo.Add(objeto);
        paquete.Equipo.Add(BuscarObjeto(objectos, 52));
        objeto = BuscarObjeto(objectos, 4);
        objeto.SetCantidad(2);
        paquete.Equipo.Add(objeto);
        objeto = BuscarObjeto(objectos,76);
        objeto.SetCantidad(5);
        paquete.Equipo.Add(objeto);
        paquete.Equipo.Add(BuscarObjeto(objectos, 101));
        paquete.Equipo.Add(BuscarObjeto(objectos, 28));
        paquete.Equipo.Add(BuscarObjeto(objectos, 34));
        objectos.Add(paquete);

        #endregion PaqueteLadron
        #region PaqueteSacerdote
        paquete = new Paquete();
        paquete.Codigo = 195;
        paquete.Nombre = "Paquete de sacerdote";
        paquete.SetValor(19);
        paquete.SetPeso(1);
        paquete.SetCantidad(1);
        paquete.TipoValor = E_Monedas.PO;
        paquete.Equipo.Add(BuscarObjeto(objectos, 57));
        paquete.Equipo.Add(BuscarObjeto(objectos, 54));
        objeto = BuscarObjeto(objectos, 98);
        objeto.SetCantidad(10);
        paquete.Equipo.Add(objeto);
        paquete.Equipo.Add(BuscarObjeto(objectos, 101));
        paquete.Equipo.Add(BuscarObjeto(objectos, 15));
        objeto = BuscarObjeto(objectos, 98);
        objeto.SetCantidad(2);
        paquete.Equipo.Add(objeto);
        paquete.Equipo.Add(BuscarObjeto(objectos,28));
        paquete.Equipo.Add(BuscarObjeto(objectos, 79));
        objectos.Add(paquete);

        #endregion PaqueteLadron
        #endregion Paquetes
        objetosFinales.Add(pathload, objectos);
        return objetosFinales;
    }
    public Objeto BuscarObjeto(List<Objeto>listaObjetos,int codigo)
    {
        Objeto objetoBuscado = new Objeto();
        bool encontrado = false;
        for(int i = 0; i < listaObjetos.Count&&!encontrado;i++)
        {
            if (listaObjetos[i].Codigo == codigo)
            {
                objetoBuscado = listaObjetos[i];
                encontrado=true;
            }
        }

        return objetoBuscado;
    }


    private Dictionary<string,List<Hechizo>> CargarHechizos()
    {
        string pathload = "Assets/Resources/Jsons/HechizosEsp.json";
        List<Hechizo>hechizos = new List<Hechizo>();
        Dictionary<string, List<Hechizo>> hechizosFinales=new Dictionary<string, List<Hechizo>>();
        Hechizo hechizo;
        #region CrearHechizos
        #region Trucos
        #region CrearHechizo1
        hechizo = new Hechizo();
        hechizo.Codigo = 1;
        hechizo.Nombre = "Agarre Electrizante";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 1;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico= true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Descripcion = "Un rel�mpago salta de tu mano para dar una descarga el�ctrica a la criatura que intentas tocar. Haz un ataque de conjuro cuerpo a cuerpo contra el objetivo. Tienes ventaja en la tirada de ataquesi la criatura lleva armadura de metal.Si impactas,el objetivosufre ld8 deda�ode rel�mpago y no podr� llevar a cabo reacciones hasta el comienzo de su pr�ximo turno.A niveles superiores. El da�o del conjuroaumenta en ld8\r\n cuandoalcanzas nivel 5 (2d8), nivel 11 (3d8)y nivel 17 (4d8).";
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo1
        #region CrearHechizo2
        hechizo = new Hechizo();
        hechizo.Codigo = 2;
        hechizo.Nombre = "Amistad";
        hechizo.EscuelaMagica = E_EscuelasMagia.ENCANTAMIENTO;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = false;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Una peque�a camtodad de maquillaje aplicada sobre la cara al lanzador del conjuro");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Hasta el final de la duraci�n del conjuro tienes ventaja en todas las pruebas de Carisma relacionadascon una criatura de tu elecci�n que nosea hostil hacia ti. Cuando el conjuro termina, el objetivose da cuenta de que has usado magia para manipular su actitud y se vuelve hostil hacia ti. Una criatura con tendencias violentas podr�a atacarte, mientrasque otra podr�a intentar vengarse de otra manera (bajo el criterio del DM), dependiendo de la �ndole de tu interacci�n con ella.";
        hechizo.ClasesAptas.Add(E_Clases.BARDO);
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo2
        #region CrearHechizo3
        hechizo = new Hechizo();
        hechizo.Codigo = 3;
        hechizo.Nombre = "Burla Da�ina";
        hechizo.EscuelaMagica = E_EscuelasMagia.ENCANTAMIENTO;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 60;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = false;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Profieres una sarta de improperios entremezclados con sutiles encantamientos hacia una criatura que puedas ver dentro del alcance. Si el objetivo puede o�rte (aunque no necesita entenderte), debe tener �xito en una tirada de salvaci�n de Sabidur�a o recibir� ld4 de da�o ps�quico y sufrir� desventaja en la siguiente tirada de ataque que realice antes del final de su pr�ximo turno. A niveles superiores.El da�o del conjuro aumenta en ld4 cuando alcanzas nivel 5 (2d4), nivel 11 (3d4) y nivel 17 (4d4).";
        hechizo.ClasesAptas.Add(E_Clases.BARDO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo3
        #region CrearHechizo4
        hechizo = new Hechizo();
        hechizo.Codigo = 4;
        hechizo.Nombre = "Crear Llama";
        hechizo.EscuelaMagica = E_EscuelasMagia.CONJURACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 10;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Aparece en tu mano una llama parpadeante.Esta perma\r\nnece hastael final de la duraci�n del conjuroy no te da�a ni\r\n a ti ni a tu equipo. La llama emite luz brillante en un radio de\r\n 10 piesy luz tenue 10 pies m�sall�. El conjuro termina si lo\r\n lanzas de nuevo osi utilizas una acci�n para finalizarlo.\r\n Tambi�n puedesatacar con la llama, pero esto termina\r\n el conjuro.Cuando lanzas este conjuro, o como acci�n en\r\n un turno posterior, puedes arrojar la llama a una criatura\r\n hasta a 30 piesde ti.Haz un ataque de conjuroa distancia.\r\n Si impactas, el objetivo recibe ld8de da�o de fuego.\r\n El da�o del conjuro aumenta en ld8cuando alcanzas\r\n nivel 5 (2d8), nivel 11 (3d8) y nivel 17 (4d8)";
        hechizo.ClasesAptas.Add(E_Clases.DRUIDA);
        hechizos.Add(hechizo);
        #endregion CrearHechizo4
        #region CrearHechizo5
        hechizo = new Hechizo();
        hechizo.Codigo = 5;
        hechizo.Nombre = "Descarga de fuego";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 120;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Arrojas una mota de fuego a una criatura u objetodentro\r\n del alcance. Haz un ataque de conjuroa distancia contra\r\n el objetivo. Si impactas, el objetivo recibe Id10 de da�o de\r\n fuego. Los objetos inflamables que se encuentren en el �rea\r\n que no lleve o vista nadie arder�n.\r\n El da�o del conjuro aumenta en 1d10 cuando alcanzas\r\n nivel 5 (2d10), nivel 11 (3dl0) y nivel 17 (4dl0).";
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo5
        #region CrearHechizo6
        hechizo = new Hechizo();
        hechizo.Codigo = 6;
        hechizo.Nombre = "Descarga sobrenatural";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 120;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = " Lanzas un rayode energ�a chisporroteante hacia una cria\r\ntura de tu elecci�n dentro del alcance. Haz un ataque de\r\n conjuro a distancia contra el objetivo. Si impactas, el obje\r\ntivo recibe Id10 de da�o de fuerza.\r\n Aniveles superiores. Este conjuro crea dos rayos a nivel\r\n 5, tres rayos a nivel 11 y cuatro rayos a fifvel 17. Puedes\r\n dirigir los rayos al mismo o a distintos objetivos. Haz una\r\n tirada de ataque separada para cada rayo.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo6
        #region CrearHechizo7
        hechizo = new Hechizo();
        hechizo.Codigo = 7;
        hechizo.Nombre = "Guardia de cuchillas";
        hechizo.EscuelaMagica = E_EscuelasMagia.ABJURACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.ASALTO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Extiendes tu manoy trazas un sello de guarda en el aire.\r\n Hasta el final de tu pr�ximo turno, tienes resistencia contra\r\n el da�o contundente, perforante y cortante que provenga de\r\n ataques con armas.";
        hechizo.ClasesAptas.Add(E_Clases.BARDO);
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo7
        #region CrearHechizo8
        hechizo = new Hechizo();
        hechizo.Codigo = 8;
        hechizo.Nombre = "Guia";
        hechizo.EscuelaMagica = E_EscuelasMagia.ADIVINACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Tocas a una criatura voluntaria. Una sola vez, antes de que\r\n termine el conjuro, el objetivo puede tirar ld4 y a�adir el\r\n resultado a una prueba de caracter�stica de su elecci�n.\r\n Puede tirar el dado antes o despu�sde conocer el resultado\r\n de la prueba. Hacer esto termina el conjuro.\r\n";
        hechizo.ClasesAptas.Add(E_Clases.CLERIGO);
        hechizo.ClasesAptas.Add(E_Clases.DRUIDA);
        hechizos.Add(hechizo);
        #endregion CrearHechizo8
        #region CrearHechizo9
        hechizo = new Hechizo();
        hechizo.Codigo = 9;
        hechizo.Nombre = "Ilusion Menor";
        hechizo.EscuelaMagica = E_EscuelasMagia.ILUSIONISMO;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 30;
        hechizo.RequisitoVocal = false;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("un poco de vell�n");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Creas un sonidoo una imagen de un objeto,situado dentro\r\n del alcance yque permanece hasta el final de la duraci�n\r\n del conjuro .La ilusi�n tambi�n termina si lanzas el conjuro\r\n de nuevo osi utilizas una acci�n para finalizarlo.\r\n Si creas unsonido,su volumen puedeestar entre el de\r\n un susurro yel de un grito. Puedeser tu voz, la de otra\r\n criatura, el rugido de un le�n, un redoblar de tambores\r\n o cualquier otro sonido de tu elecci�n. Podr� sonar en\r\n momentosconcretosocontinuamente hasta que termine el\r\n conjuro, lo que prefieras.\r\n Si creas la imagen de un objeto (como una silla, pisa\r\ndas embarradas o un peque�o cofre) no puede ser mayor\r\n que un cubode5 piesde lado. La imagen nopuede generar\r\n sonido, luz,olor o cualquier otro efecto sensorial. La inte\r\nracci�n f�sica con la imagen revela que es una ilusi�n, ya\r\n que las cosas la atraviesan.\r\n Si una criatura utiliza su acci�n para examinar la imagen\r\n o el sonido, puede determinar que es una ilusi�n si tiene\r\n �xito en una prueba de Inteligencia (Investigaci�n) cuya CD\r\n es tu salvaci�n de conjuros.Si averigua que es una ilusi�n,\r\n su aspectoe vuelve tenue para esa criatura.\r\n";
        hechizo.ClasesAptas.Add(E_Clases.BARDO);
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo9
        #region CrearHechizo10
        hechizo = new Hechizo();
        hechizo.Codigo = 10;
        hechizo.Nombre = "Impacto certero";
        hechizo.EscuelaMagica = E_EscuelasMagia.ADIVINACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 30;
        hechizo.RequisitoVocal = false;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.ASALTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = " Extiendes tu mano yse�alas con eldedo a unobjetivo\r\n dentro del alcance. Tu magia te da un moment�neo enten\r\ndimiento de las defensas del objetivo. En tu pr�ximo turno,\r\n ganasventaja en tu primera tirada deataquecontra el obje\r\ntivo, suponiendo que este conjuro no haya terminado.";
        hechizo.ClasesAptas.Add(E_Clases.BARDO);
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo10
        #region CrearHechizo11
        hechizo = new Hechizo();
        hechizo.Codigo = 11;
        hechizo.Nombre = "Latigo de espinas";
        hechizo.EscuelaMagica = E_EscuelasMagia.TRANSMUTACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 30;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("El tallo de una planta con espinas");
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = " Creas un l�tigo largo, similar a una enredadera cubierta de\r\n espinas, que fustiga bajo tus �rdenes a una criatura dentro\r\n del alcance. Haz un ataque de conjuro cuerpo a cuerpocon\r\ntra el objetivo. Si el ataque impacta, la criatura sufre ld6\r\n de da�o perforante. Adem�s, si el objetivo es de tama�o\r\n Grande o menor, tirasde �l 10 pies hacia ti.\r\n Aniveles superiores. El da�o del conjuro aumenta en\r\n ld� cuando alcanzas nivel 5(2d6), nivel 11 (3d6)y nivel 17\r\n (4d6).";
        hechizo.ClasesAptas.Add(E_Clases.ARTIFICE);
        hechizo.ClasesAptas.Add(E_Clases.DRUIDA);
        hechizos.Add(hechizo);
        #endregion CrearHechizo11
        #region CrearHechizo12
        hechizo = new Hechizo();
        hechizo.Codigo = 12;
        hechizo.Nombre = "Llama sagrada";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 60;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Un fulgor de llamas desciende sobre una criatura que pue\r\ndas ver dentro del alcance. El objetivo deber� tener �xito\r\n en una tirada de salvaci�n de Destreza o sufrir� ld8de\r\n da�o radiante. Adem�s, el objetivo no podr� beneficiarse de\r\n cobertura para esta tirada de salvaci�n.\r\n Aniveles superiores. El da�o del conjuro aumenta en ld8\r\n cuando alcanzas nivel 5 (2d8), nivel 11 (3d8) y nivel 17 (4d8).";
        hechizo.ClasesAptas.Add(E_Clases.CLERIGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo12
        #region CrearHechizo13
        hechizo = new Hechizo();
        hechizo.Codigo = 13;
        hechizo.Nombre = "Luces danzantes";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance =120;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Una pizca de f�sforo");
        hechizo.Componentes.Add("Un pedazo de olmo montano o un gusano luminiscente");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Creas hasta cuatro luces con la intensidad de antorchas\r\n dentro del alcance. Puedes darles la apariencia de antor\r\nchas, linternas u orbes luminosos, y levitan hasta el final\r\n de la duraci�n del conjuro.Tambi�n puedescombinar las\r\n cuatro luces para formar una luz de aspecto vagamente\r\n humanoide y de tama�o Mediano. En ambos casos, cada\r\n luz proyecta luz tenue en un radio de 10 pies.\r\n Comoacci�n adicional puedes mover las luces\r\n hasta 60 pies a una nueva localizaci�n dentro del alcance.\r\n Cada luz debeestar a 20 pieso menosTieotra luz creada\r\n por este conjuro y se desvanecer� si sale del alcance\r\n del mismo.";
        hechizo.ClasesAptas.Add(E_Clases.BARDO);
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo13
        #region CrearHechizo14
        hechizo = new Hechizo();
        hechizo.Codigo = 14;
        hechizo.Nombre = "Luz";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance =0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = false;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Una luciernaga o musgo florescente");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = false;
        hechizo.Descripcion = " Tocas un objeto cuyotama �osea menor o igual a 10 pies\r\n en todas las dimensiones. Hastaque elconjuro termine,\r\n el objeto emitir� luz brillante en un radiode 20 pies y luz\r\n tenue 20 pies m�s all�. La luzpuede tener el color que\r\n desees. Tapar completamente el objeto con un material\r\n opaco bloquea la luz. Elconjuro termina si lolanzas de\r\n nuevoo si utilizas una acci�n para finalizarlo.\r\n Si eligescomo objetivo un objeto portado por una cria\r\ntura hostil,esta �ltima debe tener �xito en una tirada de\r\n salvaci� n de Destreza para evitar el conjuro";
        hechizo.ClasesAptas.Add(E_Clases.BARDO);
        hechizo.ClasesAptas.Add(E_Clases.CLERIGO);
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo14
        #region CrearHechizo15
        hechizo = new Hechizo();
        hechizo.Codigo = 15;
        hechizo.Nombre = "Mano de mago";
        hechizo.EscuelaMagica = E_EscuelasMagia.CONJURACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 30;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Conjuras una manoespectral flotante en un punto de tu\r\n elecci�n dentro del alcance. La manodurar� hasta el final\r\n de la duraci�n delconjuro o hastaque utilices una acci�n\r\n para finalizarlo. Adem�s, la manodesaparecer� si en alg�n\r\n momento est� a m�s de 30 pies de ti osi lanzaseste con\r\njuro de nuevo.\r\n �\r\n Puedes emplear tu acci�n para controlar la mano,\r\n haciendo que manipule un objeto,abra una puerta o reci\r\npiente que no est� cerrado con llave,retire oguarde un\r\n objeto en un recipiente abierto ovierta el contenido de un\r\n vial.Cada vez que controles la mano deesta forma puedes\r\n tambi�n moverla hasta 30 pies.\r\n La mano no puedeatacar,activar objetos m�gicos o lle\r\nvar m�s de 10 libras de peso";
        hechizo.ClasesAptas.Add(E_Clases.BARDO);
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo15
        #region CrearHechizo16
        hechizo = new Hechizo();
        hechizo.Codigo = 16;
        hechizo.Nombre = "Mensaje";
        hechizo.EscuelaMagica = E_EscuelasMagia.TRANSMUTACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 120;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Un alambre de cobre corto");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.ASALTO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Se�alas con el dedo a una criatura dentro del alcance y\r\n susurras un mensaje. El objetivo (y solo�l) escucha el men\r\nsaje y puede contestar en un susurroquesolo t� puedes o�r.\r\n Puedes lanzar este conjuro a trav�sde objetoss�lidossi\r\n est�sfamiliarizado con el objetivo ysabes quese encuen\r\ntra tras el obst�culo. Aunque no tiene que seguir una l�nea\r\n recta y puede viajar libremente torciendo\"esquinas o atrave\r\nsando aberturas, este conjurose ve bloqueado por elsilencio\r\n m�gico, 1 pie de piedra, 1 pulgada de cualquier metal com�n,\r\n una l�mina fina de plomo o3 piesde madera otierra.";
        hechizo.ClasesAptas.Add(E_Clases.BARDO);
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo16
        #region CrearHechizo17
        hechizo = new Hechizo();
        hechizo.Codigo = 17;
        hechizo.Nombre = "Prestidigitacion";
        hechizo.EscuelaMagica = E_EscuelasMagia.TRANSMUTACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 10;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Este conjuro es un truco m�gico menor con el que practi\r\ncan los lanzadores de conjuros inexpertos. Produces uno\r\n de los siguientes efectos m�gicos, dentro del alcance:\r\n � Creas un efecto sensorial instant�neo e inofensivo, como\r\n una lluvia de chispas, una sutil r�faga de viento, leves\r\n notas musicales o un olor extra�o.\r\n � Apagas o enciendes de forma instant�nea una vela,antor\r\ncha u hoguera peque�a.\r\n � Limpias o ensucias de forma instant�nea un objeto de\r\n hasta 1 pie c�bico.\r\n � Enfr�as, calientas o das sabor a un material inerte de\r\n hasta 1 pie c�bicodurante 1 hora.\r\n � Hacesaparecer una mancha de color, una peque�a\r\n marcao uns�mboloen un objetoosuperficie durante 1 hora.\r\n ...turno...\r\n � Creas un abalorio no m�gico o una imagen ilusoria que\r\n cabe en tu mano y que dura hasta el final de tu pr�ximo\r\n _\r\n .\r\n .\r\n . . \r\n_ . ...\r\n Si lanzas este conjuro varias veces, puedes mantener\r\n hasta tres de susefectos no instant�neos activos a la vez.\r\n Para finalizar cualquiera de ellos deber�s emplear una\r\n acci�n.";
        hechizo.ClasesAptas.Add(E_Clases.BARDO);
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo17
        #region CrearHechizo18
        hechizo = new Hechizo();
        hechizo.Codigo = 18;
        hechizo.Nombre = "Rayo de escarcha";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 60;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = " Lanzas un rayo helado de luz blanquiazul hacia una cria\r\ntura de tu elecci�n que se encuentre dentro del alcance.\r\n Haz un ataque deconjuroa distancia contra el objetivo.Si\r\n impactas, el objetivo sufre ld8 de da�o de fr�o y su velo\r\ncidad queda reducida en 10 pies hasta el comienzo de tu\r\n pr�ximo turno.\r\n Aniveles superiores. El da�o del conjuro aumenta\r\n en ld8 cuando alcanzas nivel 5 (2d8), nivel 11 (3d8) y\r\n nivel 17 (4d8).";
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo18
        #region CrearHechizo19
        hechizo = new Hechizo();
        hechizo.Codigo = 19;
        hechizo.Nombre = "Reparar";
        hechizo.EscuelaMagica = E_EscuelasMagia.TRANSMUTACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Dos imanes naturales");
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Este conjuro repara una sola grieta o ruptura en un objeto\r\n que toques, como un eslab�n roto en una cadena, lasdos\r\n mitades de una llave partida, una capa rasgada o una fuga\r\n en una bota de vino. Mientras la grieta o desgarr�n nosea\r\n de m�sde1 pie en alguna dimensi�n, lo arreglassin dejar\r\n rastrodel da�o.\r\n Este conjuro puede reparar el componentef�sico de un\r\n objeto m�gico o de un aut�mata, pero no puede restaurar\r\n su magia.";
        hechizo.ClasesAptas.Add(E_Clases.BARDO);
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizo.ClasesAptas.Add(E_Clases.DRUIDA);
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo19
        #region CrearHechizo20
        hechizo = new Hechizo();
        hechizo.Codigo = 20;
        hechizo.Nombre = "Resistencia";
        hechizo.EscuelaMagica = E_EscuelasMagia.ABJURACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Una capa en miniatura");
        hechizo.Duracion =1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Tocas a una criatura voluntaria. Una sola vez, antes de que\r\n termine el conjuro, el objetivo puede tirar ld4y a�adir el\r\n resultado a una tirada desalvaci�n de su elecci�n.Puede\r\n tirar el dado antes o despu�s de conocer el resultado de la\r\n tirada. Hacer esto da por finalizado el conjuro.";
        hechizo.ClasesAptas.Add(E_Clases.CLERIGO);
        hechizo.ClasesAptas.Add(E_Clases.DRUIDA);
        hechizos.Add(hechizo);
        #endregion CrearHechizo20
        #region CrearHechizo21
        hechizo = new Hechizo();
        hechizo.Codigo = 21;
        hechizo.Nombre = "Rociada venenosa";
        hechizo.EscuelaMagica = E_EscuelasMagia.CONJURACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 10;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion =false;
        hechizo.Descripcion = "Extiendes tu mano hacia una criatura que puedasver dentro\r\n del alcancey la fumigascon una nubede gas venenosoquesale\r\n de la palma de tu mano.Deber� tener�xitoen una tirada de sal\r\nvaci�n deConstituci�n osufrir� Id12 de da�odeveneno.\r\n El da�o del conjuro aumenta en 1d12 cuandoalcanzas\r\n nivel 5(2d12), nivel 11 (3dl2)y nivel 17 (4dl2).";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizo.ClasesAptas.Add(E_Clases.DRUIDA);
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo21
        #region CrearHechizo22
        hechizo = new Hechizo();
        hechizo.Codigo = 22;
        hechizo.Nombre = "Saber Druidico";
        hechizo.EscuelaMagica = E_EscuelasMagia.TRANSMUTACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 30;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Susurrando a los esp�ritus de la naturaleza, produces uno\r\n de los siguientes efectos m�gicos:\r\n � Creasun efecto sensorial diminuto e inofensivo que pre\r\ndice c�moser� el tiempoatmosf�ricoen tulocalizaci�n\r\n en las pr�ximas 24 horas.El efecto podr�a manifestarse\r\n como un orbe dorado para un d�a despejado, una nube\r\n indicando lluvia, copos de nieve para nieve, etc. Este\r\n efecto dura 1 asalto.\r\n � Hacesque unaflor florezca inmediatamente,que una vaina\r\n de semillasse abra o queel brotede una hoja germine.\r\n � Creas un efectosensorial instant�neo e inofensivo, como\r\n hojas cayendo, una r�faga de viento, el sonido de un\r\n animal peque�o o un leve olor a mofeta. El efecto debe\r\n quedar confinado a un cubo de 5 pies.\r\n � Apagaso enciendes de forma instant�nea una vela, antor\r\ncha u hoguera peque�a.\r\n";
        hechizo.ClasesAptas.Add(E_Clases.DRUIDA);
        hechizos.Add(hechizo);
        #endregion CrearHechizo22
        #region CrearHechizo23
        hechizo = new Hechizo();
        hechizo.Codigo = 23;
        hechizo.Nombre = "Salpicadura acida";
        hechizo.EscuelaMagica = E_EscuelasMagia.CONJURACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 60;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = " Lanzas una burbuja de �cido. Elige una criatura dentro del\r\n alcance o dos criaturas dentro del alcanceseparadas 5 pies\r\n o menos la una de la otra. Cada objetivo deber� tener �xito\r\n en una tirada de salvaci�n de Destreza o sufrir� ld� de\r\n da�ode�cido.\r\n El da�o del conjuroaumenta en ld�cuandoalcanzas\r\n nivel 5 (2d�), nivel 11 (3d�) y nivel 17 (4d�).";
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo23
        #region CrearHechizo24
        hechizo = new Hechizo();
        hechizo.Codigo = 24;
        hechizo.Nombre = "Shillelagh";
        hechizo.EscuelaMagica = E_EscuelasMagia.TRANSMUTACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION_ADICIONAL;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("muerdago");
        hechizo.Componentes.Add("una hoja de tr�bol");
        hechizo.Componentes.Add("un garrote o bast�n");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "La madera de un bast�n o garrote que empu�as queda\r\n imbuida con el poder de la naturaleza. Hasta el final de\r\n la duraci�n del conjuro puedes usar tu aptitud m�gica\r\n en vez de tu Fuerza para las tiradas de ataque y da�o\r\n al utilizar esta arma, y su dado de da�o pasa a ser ld8.\r\n Adem�s, el arma se convierte en m�gica si no lo era\r\n ya. El conjuro termina si lo lanzas de nuevo o si sueltas\r\n el arma";
        hechizo.ClasesAptas.Add(E_Clases.DRUIDA);
        hechizos.Add(hechizo);
        #endregion CrearHechizo24
        #region CrearHechizo25
        hechizo = new Hechizo();
        hechizo.Codigo = 25;
        hechizo.Nombre = "Taumaturgia";
        hechizo.EscuelaMagica = E_EscuelasMagia.TRANSMUTACION;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 30;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = false;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Manifiestas un peque�o milagro ose�al de poder sobre\r\nnatural dentro del alcance. Produces uno de lossiguientes\r\n efectos m�gicos:\r\n � Tu voz resuena hasta tres veces m�s fuerte de lo normal\r\n durante 1 minuto.\r\n � Haces que una llama titile, cambie la intensidad de su\r\n brillo o modifique su color durante 1 minuto.\r\n � Hacesque la tierra tiemble inofensivamente durante\r\n 1 minuto.\r\n � Creas un sonidoinstant�neo, que tiene como origen un\r\n punto de tu elecci�n dentro del alcance. Por ejemplo, el\r\n retumbar de un trueno, el graznido de un cuervo o unos\r\n susurros de mal ag�ero.\r\n � Hacesque una puerta o ventana que noest� cerrada con\r\n llave se abra o cierre de golpe.\r\n � Cambiasel aspecto de tus ojosdurante 1 minuto.\r\n Si lanzas este conjuro varias veces, puedes mantener\r\n hasta tres de sus efectos no instant�neos activos a la\r\n vez. Para finalizar cualquiera de ellos deber�s emplear\r\n una acci�n.";
        hechizo.ClasesAptas.Add(E_Clases.CLERIGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo25
        #region CrearHechizo26
        hechizo = new Hechizo();
        hechizo.Codigo = 26;
        hechizo.Nombre = "Toque helado";
        hechizo.EscuelaMagica = E_EscuelasMagia.NIGROMANCIA;
        hechizo.Nivel = 0;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 120;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.ASALTO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Creas una mano fantasmag�rica en el espacio de una\r\n criatura dentro del alcance. Haz un ataque de conjuro\r\n a distancia contra la criatura para agredirla con un fr�o\r\n sepulcral.Si impactas, el objetivo sufre ld8 de da�o\r\n necr�tico y no podr� recuperar puntos de golpe hasta el\r\n comienzo de tu pr�ximo turno. Hasta ese momento, la\r\n manose aferra al objetivo.\r\n Si, adem�s,el objetivo impactado es un muerto viviente,\r\n tendr� desventaja en sus tiradas de ataque contra ti hasta el\r\n final de tu pr�ximo turno.\r\n Aniveles superiores.El da�o del conjuro aumenta en ld8\r\n cuando alcanzas nivel 5(2d8), nivel 11(3d8) y nivel 17 (4d8).";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo26
        #endregion Trucos
        #region Nivel1
        #region CrearHechizo27
        hechizo = new Hechizo();
        hechizo.Codigo = 27;
        hechizo.Nombre = "Alarma";
        hechizo.EscuelaMagica = E_EscuelasMagia.ABJURACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Alcance = 30;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Una peque�a campana");
        hechizo.Componentes.Add("Un hilo de plata fina");
        hechizo.Duracion = 8;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = false;
        hechizo.Descripcion = " Preparas una alarma contra intrusos. Elige una puerta,\r\n ventana o cualquier otra �rea dentro del alcance cuyo\r\n volumen sea menoro igual que un cubode 20 pies de\r\n lado. Una alarma te avisar� siempre que una criatura,\r\n Diminuta o de tama�osuperior, toque oentre en la zona\r\n vigilada antes del final del conjuro. Al lanzarlo puedes ele\r\ngir que ciertas criaturas no activar�n la alarma,que puede\r\n ser mental osonora.\r\n Unaalarma mental te alerta con un sonidodentrode tu\r\n mente si est�s a 1 milla de la zona vigilada.Si est�s dor\r\nmido, te despertar�.\r\n Una alarma sonora produce un sonido decampanilla\r\n durante 10 segundos audible a 60 pies de distancia.";
        hechizo.ClasesAptas.Add(E_Clases.EXPLORADOR);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo27
        #region CrearHechizo28
        hechizo = new Hechizo();
        hechizo.Codigo = 28;
        hechizo.Nombre = "Armadura de mago";
        hechizo.EscuelaMagica = E_EscuelasMagia.ABJURACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Una taza de agua");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = false;
        hechizo.Descripcion = " Una fuerza m�gica protectora te rodea ,manifest�ndose como unaescarcha espectral quete cubre por completo,\r\n incluido a tu equipo .Ganas 5puntos de golpetemporales\r\n hasta el final de la duraci� ndel conjuro. Si unacriatura te\r\n impacta con unataque cuerpo acuerpo mientras conservas\r\n estos puntos ,esta sufre 5 de da �o de fr�o.\r\n Anivelessuperiores .Cuandolanzas esteconjuro uti\r\nlizando unespacio deconjuro de nivel 2o m�s,tanto los\r\n puntos degolpe temporales comoel da�o de fr�o aumentan\r\n en5 por cada nivel porencima de1que tenga elespacio\r\n que hayas empleado";
        hechizo.ClasesAptas.Add(E_Clases.HECHICERO);
        hechizo.ClasesAptas.Add(E_Clases.MAGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo28
        #region CrearHechizo29
        hechizo = new Hechizo();
        hechizo.Codigo = 29;
        hechizo.Nombre = "Bendicion";
        hechizo.EscuelaMagica = E_EscuelasMagia.ENCANTAMIENTO;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 30;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Unas gotas de agua bendita");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Bendices hasta tres criaturas de tu elecci�n dentro del\r\n alcance. Hasta el final de la duraci�n del conjuro, cuando\r\n uno de los objetivos haga una tirada de ataque o una\r\n tirada de salvaci�n, puede tirar ld4 y a�adir el resultado\r\n a esa tirada.\r\n Aniveles superiores. Cuando lanzas este conjuro utili\r\nzando un espacio deconjuro de nivel 2 o m�s, puedeselegir\r\n como objetivo-a una criatura adicional ^or cada nivel por\r\n encima de 1 que tenga el espacio que hayas empleado.";
        hechizo.ClasesAptas.Add(E_Clases.PALADIN);
        hechizo.ClasesAptas.Add(E_Clases.CLERIGO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo29
        #region CrearHechizo30
        hechizo = new Hechizo();
        hechizo.Codigo = 30;
        hechizo.Nombre = "Brazos de Hadar";
        hechizo.EscuelaMagica = E_EscuelasMagia.CONJURACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 10;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Invocas el poder de Hadar, el Hambre Tenebrosa. Zarci\r\nllos de energ�a oscura surgen de ti y golpean a todas las\r\n criaturas a 10 pies o menos de tu posici�n. Cada criatura\r\n en el �rea debe hacer una tirada de salvaci�n de Fuerza.\r\n Si falla, sufrir� 2d6 de da�o necr�tico y no podr� llevar a\r\n cabo reacciones hasta el comienzo de su pr�ximo turno.\r\n Si supera la tirada, recibir� la mitad de da�o, pero no\r\n sufrir� ning�n otro efecto.\r\n Aniveles superiores.Cuando lanzaseste conjuro uti\r\nlizando un espacio de conjuro de nivel 2 o m�s, el da�o\r\n aumenta en ld� por cada nivel por encima de 1que tenga\r\n el espacio que hayasempleado.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo30
        #region CrearHechizo31
        hechizo = new Hechizo();
        hechizo.Codigo = 31;
        hechizo.Nombre = "Bruenas bayas";
        hechizo.EscuelaMagica = E_EscuelasMagia.TRANSMUTACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("un ramito de m�erdago");
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Aparecen en tu mano un m�ximo de diez bayas infundidas\r\n con magia hasta el final de la duraci�n del conjuro. Una\r\n criatura puede utilizar su acci�n para comerse una baya.\r\n Si hace esto recuperar� 1 punto de golpe y tendr� sustento\r\n para todo el d�a.\r\n Las bayas pierden su poder si noson consumidasdentro\r\n de las 24 horassiguientes al lanzamiento del conjuro.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo31
        #region CrearHechizo32
        hechizo = new Hechizo();
        hechizo.Codigo = 32;
        hechizo.Nombre = "Caida pluma";
        hechizo.EscuelaMagica = E_EscuelasMagia.TRANSMUTACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.REACCION;
        hechizo.Alcance = 60;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = false;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Una pluma peque�a o un poco de plum�n");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Elige un m�ximo de cinco criaturas dentro del alcance que\r\n est�n cayendo. La velocidad de ca�da de cada objetivo se\r\n reduce a 60 pies por asalto hasta que el conjuro termine. Si\r\n alguna criatura llega al suelo antes de que esto suceda, no\r\n recibe da�o por ca�da, sino que puede caer de pie y el con\r\njuro acaba para ese objetivo.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo32
        #region CrearHechizo33
        hechizo = new Hechizo();
        hechizo.Codigo = 33;
        hechizo.Nombre = "Castigo abrasador";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION_ADICIONAL;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = false;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = " La pr�xima vez que impactes a una criatura con unataque\r\n con armacuerpoa cuerpo antes del final de laduraci� ndel\r\n conjuro, tu armase calienta hasta el rojo vivoy elataque\r\n inflige ld� de da �o defuego adicional al objetivo, haciendo\r\n que comience a arder. Al iniciode cada uno desus turnos ,\r\n el objetivo debe realizar una tirada desalvaci�nde Consti\r\ntuci� n.Si falla , recibe ld� de da�o de fuego. Si tiene �xito\r\n en la tirada, elconjuro termina inmediatamente.Si el obje\r\ntivo o una criatura a 5pies deeste utiliza una acci�n para\r\n apagar las llamas, o si otro efectolas sofoca (como sumer\r\ngir al objetivoen agua) ,el conjuro termina.\r\n Anivelessuperiores. Cuandolanzaseste conjuro uti\r\nlizando un espacio deconjuro de nivel 2 o m�s ,el da �o\r\n adicional del ataque aumenta en ld� por cada nivel por\r\n encima de 1 delespacio.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo33
        #region CrearHechizo34
        hechizo = new Hechizo();
        hechizo.Codigo = 34;
        hechizo.Nombre = "Castigo atronador";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION_ADICIONAL;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = false;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = " La pr�xima vez que impactes a una criatura con un ata\r\nque con arma antes del final de la duraci�n del conjuro, tu\r\n armasuena como un truenoaudiblea 300 piesde distan\r\ncia y el ataque inflige 2d� de da�o de trueno adicionales al\r\n objetivo.Si el objetivo es una criatura, deber� superar una\r\n tirada de salvaci�n de Fuerza oser� empujada 10 piesen\r\n direcci�n opuesta a ti yser� derribada.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo34
        #region CrearHechizo35
        hechizo = new Hechizo();
        hechizo.Codigo = 35;
        hechizo.Nombre = "Castigo furioso";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION_ADICIONAL;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = false;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "La pr�xima vezque impactes a una criatura con un ataque\r\n conarma antes del final de la duraci�n del conjuro, el ata\r\nque le infligir� ld� deda�ops�quico adicional. Adem�s ,el\r\n objetivo debe tener �xito en una tirada de salvaci�n de Sabi\r\ndur�a o quedar� asustado por ti hasta el final de la duraci�n\r\n del conjuro. Podr� utilizar su acci�n para hacer una prueba\r\n de Sabidur�a con CDigual a tu salvaci�nde conjuros para\r\n recuperar su bravura y terminar elconjuro.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo35
        #region CrearHechizo36
        hechizo = new Hechizo();
        hechizo.Codigo = 36;
        hechizo.Nombre = "Crear o destruir agua";
        hechizo.EscuelaMagica = E_EscuelasMagia.TRANSMUTACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 30;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("una gota de agua si estas creandola o unas granos de arena si la estas destruyendo");
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Creas o destruyes agua.\r\n Crear agua.Creas hasta 10 galones de agua limpia en\r\n un recipiente dentro del alcance. Alternativamente, el agua\r\n llueve en un cubo de 30 piesde lado dentro del alcance,\r\n apagando cualquier llama expuesta dentro del �rea.\r\n Destruir agua. Destruyes hasta 10 galones de agua\r\n limpia de un recipiente dentro del alcance. Alternativa\r\nmente, deshaces la niebla en un cubo de 30 pies de lado\r\n dentro del alcance.\r\n A niveles superiores.Cuando lanzas este conjuro\r\n utilizando un espacio de conjuro de nivel 2 o m�s, por\r\n cada nivel por encima de 1 del espacio creas o destru\r\nyes 10 galones adicionales de agua o el lado del cubo\r\n aumenta en 5 pies.\r\n";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo36
        #region CrearHechizo37
        hechizo = new Hechizo();
        hechizo.Codigo = 37;
        hechizo.Nombre = "Curar heridas";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Una criatura a la que toques recupera tantos puntosde\r\n golpe como ld8+ tu modificador por aptitud m�gica.Este\r\n conjuro no afecta a muertos vivientesoaut�matas.\r\n Aniveles superiores. Cuando lanzas este conjuro utili\r\nzando unespaciode conjurode nivel 2 om�s, la curaci�n\r\n aumenta en ld8 por cada nivel porencima de 1 que tenga\r\n el espacioque hayasempleado.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo37
        #region CrearHechizo38
        hechizo = new Hechizo();
        hechizo.Codigo = 38;
        hechizo.Nombre = "Detectar el bien y el mal";
        hechizo.EscuelaMagica = E_EscuelasMagia.ADIVINACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 10;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Hasta el final del conjuro, sabes si hay aberraciones, celestiales, elementales, fe�ricos, demonios o muertos vivientes\r\n en un radio de 30 pies a tu alrededor, as�comosu ubica\r\nci�n exacta. De forma similar, percibessi hay un lugar u\r\n objeto a 30 pies de ti que haya sidoconsagradoo desecrado\r\n m�gicamente.\r\n Este conjuro escapaz de atravesar la mayor�a de las\r\n barreras, pero se ve bloqueado por 1 pie de piedra, 1 pul\r\ngada de cualquier metal com�n, una fina l�mina de plomoo\r\n 3pies de madera otierra.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo38
        #region CrearHechizo39
        hechizo = new Hechizo();
        hechizo.Codigo = 39;
        hechizo.Nombre = "Detectar magia";
        hechizo.EscuelaMagica = E_EscuelasMagia.ADIVINACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 10;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Hasta que termine la duraci�n del conjuro podr�s perci\r\nbir la presencia de magia a 30 pies o menos de ti.Si la\r\n detectas de esta manera, puedes usar tu acci�n para ver\r\n una d�bil aura alrededor de cualquier objeto o criatura\r\n visible que est� afectada por la magia, y adem�s podr�s\r\n distinguir a qu� escuela pertenece, si es que pertenece\r\n a alguna.\r\n Este conjuro es capaz de atravesar la mayor�a de las\r\n barreras, pero se ve bloqueado por 1 pie de piedra, 1 pul\r\ngada de cualquier metal com�n, una l�mina fina de plomoo\r\n 3pies de madera o tierra.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo39
        #region CrearHechizo40
        hechizo = new Hechizo();
        hechizo.Codigo = 40;
        hechizo.Nombre = "Detectar magia";
        hechizo.EscuelaMagica = E_EscuelasMagia.ADIVINACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("una hoja de tejo");
        hechizo.Duracion = 10;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Hasta que termine la duraci�n del conjuro podr�s perci\r\nbir la presencia de magia a 30 pies o menos de ti.Si la\r\n detectas de esta manera, puedes usar tu acci�n para ver\r\n una d�bil aura alrededor de cualquier objeto o criatura\r\n visible que est� afectada por la magia, y adem�s podr�s\r\n distinguir a qu� escuela pertenece, si es que pertenece\r\n a alguna.\r\n Este conjuro es capaz de atravesar la mayor�a de las\r\n barreras, pero se ve bloqueado por 1 pie de piedra, 1 pul\r\ngada de cualquier metal com�n, una l�mina fina de plomoo\r\n 3pies de madera o tierra.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo40
        #region CrearHechizo41
        hechizo = new Hechizo();
        hechizo.Codigo = 41;
        hechizo.Nombre = "Disco flotante de Tenser";
        hechizo.EscuelaMagica = E_EscuelasMagia.CONJURACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 30;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("una gota de mercurio");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = true;
        hechizo.Descripcion = " Este conjuro crea un plano circular y horizontal de\r\n fuerza, de 3 pies de di�metro y 1 pulgada de espesor, que\r\n flota a 3 pies del suelo en un espacio desocupado de tu\r\n elecci�n que puedas ver dentro del alcance. El disco per\r\nmanece hasta el final de la duraci�n del conjuro y puede\r\n cargar hasta 500 libras. Si se pone m�s peso encima,\r\n el conjuro termina y todo lo que hubiera en el disco cae\r\n al suelo.\r\n El disco permanecer� inm�vil mientras est�s a 20 pies\r\n o menos de �l.Si te alejas m�sde 20 pies, te seguir� para\r\n mantenerse a esa distancia. Puede moverse sobre terreno\r\n desigual, subir o bajar escaleras, cuestas y similares, pero\r\n no puede cruzar un cambiode elevaci�n de 10 o m�s pies.\r\n Por ejemplo, el disco no puede moverse a trav�s de un pozo\r\n de 10 pies de profundidad, ni podr� salir de dicho pozo si\r\n es creado en el fondo.\r\n Si te alejas a m�s de 100 piesdel disco(normalmente\r\n porque no puede rodear un obst�culo para seguirte), el con\r\njuro termina.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo41
        #region CrearHechizo42
        hechizo = new Hechizo();
        hechizo.Codigo = 42;
        hechizo.Nombre = "Disfrazarse";
        hechizo.EscuelaMagica = E_EscuelasMagia.ILUSIONISMO;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Haces que t� (incluyendo tu vestimenta, armadura, armas\r\n y otras posesiones que lleves contigo) parezcas diferente\r\n hasta que el conjuro finalice o utilices tu acci�n para ter\r\nminarlo. Puedes\r\n ^arecer 1 pie m�saltoo m�s bajoy de\r\n complexi�n delgada, gorda o intermedia. No puedes cam\r\nbiar el tipo de tu cuerpo, as� que debes adoptar una forma\r\n que tenga la misma configuraci�n de miembros. El resto de\r\n aspectos pueden ser afectados por la ilusi�n.\r\n Los cambios realizados por este conjuro no aguantan\r\n una inspecci�n f�sica. Por ejemplo, si usas este conjuro\r\n para a�adir un sombreroa tu vestimenta, los objetos atra\r\nviesan el sombrero y cualquiera que lo toque no sentir�a\r\n nada, o sencillamente notar�a tu pelo y'G'gbeza. Si utilizas\r\n este conjuro para parecer m�s delgado, la mano de cual\r\nquiera que intente tocarte se chocar� contigo en lo que\r\n parece ser espacio libre.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo42
        #region CrearHechizo43
        hechizo = new Hechizo();
        hechizo.Codigo = 43;
        hechizo.Nombre = "Dormir";
        hechizo.EscuelaMagica = E_EscuelasMagia.ENCANTAMIENTO;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 90;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Una pizca de arena fina");
        hechizo.Componentes.Add("p�talos de rosa o un grillo");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion =false;
        hechizo.Descripcion = " Este conjuro sume a tusobjetivos en un sue�o m�gico.\r\n Tira 5d8; podr�safectar a criaturas cuyo total combinado\r\n de puntos de golpe sea menor o igual al resultado. Las\r\n criaturas a 20 pies de un puntode tu elecci�n dentro del\r\n alcance son afectadas en orden ascendente desus puntos\r\n de golpe actuales. Ignora a las criaturas inconscientes.\r\nEmpezando por la criatura que tenga el menor n�mero\r\n de puntos de golpe actuales, cada criatura afectada por\r\n este conjuro cae inconsciente hasta el final del conjuro,\r\n hasta recibir da�o o hasta que alguien utilice su acci�n\r\n para despertarla. Resta del total los puntos de golpe de\r\n cada criatura a la que duermas antes de continuar con la\r\n siguiente. Una criatura solo se ver� afectada si sus puntos\r\n de golpe actualesson menores o iguales al total restante.\r\n Los muertos vivientes y las criaturas inmunes a ser\r\n hechizadas no se ven afectadas por este conjuro.\r\n Aniveles superiores.Cuando lanzaseste conjuro uti\r\nlizando un espacio de conjuro de nivel 2 o m�s, tira 2d8\r\n adicionales por cada nivel por encima de 1 que tenga el\r\n espacio que hayasempleado.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo43
        #region CrearHechizo44
        hechizo = new Hechizo();
        hechizo.Codigo = 44;
        hechizo.Nombre = "Duelo forzado";
        hechizo.EscuelaMagica = E_EscuelasMagia.ENCANTAMIENTO;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION_ADICIONAL;
        hechizo.Alcance = 30;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = false;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = " Intentas forzar a una criatura a un duelo. Un objetivo de tu\r\n elecci�n que puedasver dentro del alcance debe realizar\r\n una tirada de salvaci�n de Sabidur�a.Si la falla, la criatura\r\n ve su atenci�n atra�da hacia ti, obligada por tu demanda\r\n divina. Hasta el final de la duraci�n del conjuro, tiene des\r\nventaja en las tiradas de ataque contra criaturas distintas\r\n a ti y debe hacer una tirada de salvaci�n de Sabidur�a cada\r\n vez que intente moverse a un espacioa m�s de 30 pies de ti;\r\n si tiene �xito, no ve su movimiento restringido por este con\r\njuro durante este turno.\r\n El conjuro termina si atacas a otra criatura, si lanzas un\r\n conjuro que tiene como objetivo a una criatura hostil dis\r\ntinta, si una criatura amistosa hacia ti da�a al objetivo o\r\n le lanza un conjuro da�ino, osi acabas tu turno a m�s de\r\n 30 pies del objetivo.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo44
        #region CrearHechizo45
        hechizo = new Hechizo();
        hechizo.Codigo = 45;
        hechizo.Nombre = "Encantar animal";
        hechizo.EscuelaMagica = E_EscuelasMagia.ENCANTAMIENTO;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 30;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Unas migajas de comida");
        hechizo.Duracion = 24;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = false;
        hechizo.Descripcion = " Este conjuro te permite convencer a una bestia de que no\r\n quieres hacerle da�o. Elige a una bestia que puedas ver\r\n dentro del alcance. Debe ser capaz de verte y o�rte.Si su\r\n inteligencia es 4 o m�s, el conjuro falla. En caso contrario,\r\n el objetivo debe superar una tirada de salvaci�n de Sabidu\r\nr�a o quedar� hechizado por ti hasta el final de la duraci�n\r\n del conjuro.Si t� o cualquiera de tus compa�eros da��is al\r\n objetivo, el conjuro termina.\r\n Aniveles superiores. Cuando lanzas este conjuro uti\r\nlizando un espacio de conjuro de nivel 2 o m�s, puedes\r\n elegir como objetivo una bestia adicional por cada nivel por\r\n encima de 1que tenga el espacio que hayasempleado.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo45
        #region CrearHechizo46
        hechizo = new Hechizo();
        hechizo.Codigo = 46;
        hechizo.Nombre = "Encontrar familiar";
        hechizo.EscuelaMagica = E_EscuelasMagia.CONJURACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Alcance = 10;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("10 po de carb�n");
        hechizo.Componentes.Add("Incieso");
        hechizo.Componentes.Add("Hierbas");
        hechizo.Componentes.Add("Brasero de bronce");
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Obtienes los servicios de un familiar, un esp�ritu que\r\n adopta una forma animal de tu elecci�n: ara�a, coma\r\ndreja, b�ho, caballito de mar, cangrejo, cuervo, gato,\r\n halc�n, lagarto, murci�lago, pez (mordedor), pulpo, rana\r\n (sapo), rata o serpiente venenosa. Aparece en un espacio\r\n libre dentro del alcance y tiene el perfd de la forma ele\r\ngida, aunque su tipo es celestial, fe�rico o infernal (a tu\r\n elecci�n) en vez de bestia.\r\n Tu familiar act�a de forma independiente, perosiempre\r\n obedece tus�rdenes. En combate hacesu propia tirada de\r\n iniciativa y act�a en su propio turno. Un familiar no puede\r\n atacar, pero puede realizar otras accionescon normalidad.\r\n Si sus puntos de golpe se reducen a 0 desaparece sin\r\n dejar rastro f�sico alguno. Reaparecer� cuando lanceseste\r\n conjuro de nuevo. Mientras tu familiar est� a 100 pies de ti,\r\n puedes comunicarte con �l telep�ticamente. Adem�s, pue\r\ndes usar tu acci�n para ver a trav�sde losojos del familiar\r\n y o�r lo que �l oiga hasta el comienzode tu pr�ximo turno,\r\n ganando los beneficios de cualquier sentido especial que\r\n posea. Durante este tiempo, permanecer�ssordoy ciego\r\n respecto a tus propiossentidos.\r\n Puedes usar tu acci�n para desconvocar temporalmente\r\n a tu familiar. Se retira a una dimensi�n de bolsillo, donde\r\n espera a ser convocado de nuevo. Tambi�n puedesdescon\r\nvocarlo para siempre. Mientrasse encuentre temporalmente\r\n desconvocado, puedes usar una acci�n para hacer que rea\r\nparezca en un espacio desocupadoa 30 pieso menosde ti.\r\n No puedes tener m�s de un familiar al mismo tiempo.\r\n Si lanzas este conjuro cuando ya tienes uno haces que el\r\n actual adopte una forma nueva. El�gela de la lista anterior.\r\n Tu familiar se transforma en la criatura escogida.\r\n Por �ltimo, cuandolanzas un conjurocon un alcancede\r\n toque, puedes hacer que tu familiar sea el que toquea tu obje\r\ntivo, comosi �l hubiera lanzadoel conjuro.Tu familiardebe\r\n permanecera 100 piesomenosdetiyusarsu reacci�n para\r\n tocar al objetivo cuandolanzasel conjuro.Si este requiere una\r\n tirada de ataque, utiliza tu modificador de ataque para la tirada.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo46
        #region CrearHechizo47
        hechizo = new Hechizo();
        hechizo.Codigo = 47;
        hechizo.Nombre = "Enmara�ar";
        hechizo.EscuelaMagica = E_EscuelasMagia.CONJURACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 90;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Ra�ces, vides y malas hierbas brotan del suelo, intentando\r\n agarrar a las criaturas en un cuadrado de 20 pies de lado\r\n situado en un puntodentro del alcance. Hasta el final de la\r\n duraci�n del conjuro, estas plantas transforman el suelo del\r\n �rea en terreno dif�cil.\r\n Cualquier criatura que se encuentre en dicho'espacio\r\n cuando lanzas el conjuro debe tener �xito en una tirada\r\n de salvaci�n de Fuerza oquedar� apresada por las plan\r\ntas enredadoras hasta el final del conjuro. Una criatura\r\n apresada puede utilizar su acci�n para hacer una prueba\r\n de Fuerza con CD igual a tu salvaci�n de conjuros. Si la\r\n supera, queda libre.\r\n Cuandoel conjuro termina, las plantas conjuradasse\r\n marchitan y sesecan.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo47
        #region CrearHechizo48
        hechizo = new Hechizo();
        hechizo.Codigo = 48;
        hechizo.Nombre = "Entender Idiomas";
        hechizo.EscuelaMagica = E_EscuelasMagia.ADIVINACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 90;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Una pizca de hollin y sal");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Hasta que termine la duraci�n del conjuro, entiendes el sig\r\nnificado literal de las palabras que escuches en cualquier\r\n idioma. Tambi�n comprendes todos los textos escritos que\r\n veas, independientemente del lenguaje, pero debes poder\r\n tocar la superficie sobre la que est�n inscritos. Tardas\r\n 1minuto en leer una p�gina.\r\n Este conjuro no descifra mensajessecretos de un texto o\r\n glifo, como un sello arcano, que no forme parte de un len\r\nguaje escrito.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo48
        #region CrearHechizo49
        hechizo = new Hechizo();
        hechizo.Codigo = 49;
        hechizo.Nombre = "Escudo de fe";
        hechizo.EscuelaMagica = E_EscuelasMagia.ABJURACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION_ADICIONAL;
        hechizo.Alcance = 60;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Un peque�o pergamino que contenga un fragmento de texto sagrado");
        hechizo.Duracion = 10;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = " Un campo titilante envuelve a una criatura de tu elecci�n\r\n dentro del alcance, otorg�ndole un bonificador de +2 a la\r\n CA hasta el final de la duraci�n del conjuro";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo49
        #region CrearHechizo50
        hechizo = new Hechizo();
        hechizo.Codigo = 50;
        hechizo.Nombre = "Escudo de fe";
        hechizo.EscuelaMagica = E_EscuelasMagia.NIGROMANCIA;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("una peque�a cantidad de alcohol o bebidas espirituosas");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = false;
        hechizo.Descripcion = " Fortaleci�ndote mediante una imitaci�n nigrom�ntica de\r\n vida, ganas ld4+4 puntos de golpe temporales hasta el final\r\n de la duraci�n del conjuro.\r\n Aniveles superiores.Cuando lanzas este conjuro utili\r\nzando un espacio de conjuro de nivel 2 o m�s, los puntos\r\n de golpe temporales aumentan en 5 m�s por cada nivel\r\n por encima de 1 que tenga el espacio que hayas empleado.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo50
        #region CrearHechizo51
        hechizo = new Hechizo();
        hechizo.Codigo = 51;
        hechizo.Nombre = "Favor divino";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION_ADICIONAL;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = false;
        hechizo.Descripcion = " Tu plegaria te fortifica con un resplandor divino. Hasta que\r\n el conjuro termine, tus ataques con arma infligen ld4 de\r\n da�o radiante adicional.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo51
        #region CrearHechizo52
        hechizo = new Hechizo();
        hechizo.Codigo = 52;
        hechizo.Nombre = "Fuego feerico";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 60;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = false;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = true;
        hechizo.Descripcion = " El conjuro ilumina con luz azul, verde o violeta, a tu elec\r\nci�n, el contorno de todos los objetos en un cubo de 20 pies\r\n dentro del alcance. Se ilumina tambi�n el contorno de\r\n cualquier criatura dentro del �rea que falle una tirada de\r\n salvaci�n de Destreza. Hasta el final de la duraci�n del con\r\njuro, los objetos y criaturas afectados emiten luz tenue en\r\n un radio de 10 pies.\r\n Todaslas tiradas de ataque contra una criatura u objeto\r\n afectado tienen ventaja si el atacante puede ver a su obje\r\ntivo. Adem�s, aunque sean invisibles no recibir�n ninguno\r\n de los beneficios de ese estado mientras sigan afectados\r\n por fuego fe�rico.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo52
        #region CrearHechizo53
        hechizo = new Hechizo();
        hechizo.Codigo = 53;
        hechizo.Nombre = "Grasa";
        hechizo.EscuelaMagica = E_EscuelasMagia.CONJURACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 60;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Un poco de piel de cerdo o de mantequilla");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = " Una grasa resbaladiza cubre el suelo en un cuadrado de\r\n 10 pies centrado en un punto dentro del alcance, convir\r\nti�ndolo en terreno dif�cil hasta el finaide la duraci�n\r\n del conjuro.\r\n Cuando la grasa aparece, todas las criaturas de pie en\r\n la zona afectada deben tener �xito en una tiradade salva\r\nci�n de Destreza o quedar�n derribadas. Una criatura que\r\n entre en la zona o acabe su turno en ella tambi�n debe\r\n tener �xito en una tirada de salvaci�n de Destreza o que\r\ndar� derribada.\r\n";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo53
        #region CrearHechizo54
        hechizo = new Hechizo();
        hechizo.Codigo = 54;
        hechizo.Nombre = "Hablar con los animales";
        hechizo.EscuelaMagica = E_EscuelasMagia.ADIVINACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 10;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Ganas la capacidad de comprender ycomunicarte verbal\r\nmente con bestias hasta el final de la duraci�n del conjuro. El\r\n conocimientoy conciencia de muchas criaturasest� limitado\r\n por su inteligencia, pero como m�nimo podr�n proporcionarte\r\n informaci�n sobre lugaresy monstruoscercanos, incluyendo\r\n lo que puedan percibir o hayan percibido en el �ltimo d�a. Es\r\n posible que seascapaz de convencer a una bestia de que te\r\n haga un peque�o favor,seg�n el criterio del DM.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo54
        #region CrearHechizo55
        hechizo = new Hechizo();
        hechizo.Codigo = 55;
        hechizo.Nombre = "Hechizar persona";
        hechizo.EscuelaMagica = E_EscuelasMagia.ENCANTAMIENTO;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 30;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = false;
        hechizo.Descripcion = " Intentas hechizar a un hurnanoide que puedas ver dentro\r\n del alcance. El objetivo debe hacer una tirada de salva\r\nci�n de Sabidur�a,con ventaja si est� luchandocontra ti\r\n o tuscompa�eros.Si falla la tirada de salvaci�n,queda\r\n hechizado por ti hasta que termine la duraci�n del con\r\njuro , o t� mismo o uno de tus compa�eros leda��is de\r\n alguna manera. La criatura hechizada te considera un\r\n conocido amistoso. Cuando el conjuro termine,sabr� que\r\n la hechizaste.\r\n Aniveles superiores.Cuando lanzas este conjuro utili\r\nzando un espacio de conjuro de nivel 2 o m�s, puedes elegir\r\n comoobjetivoa una criatura adicional por cada nivel por\r\n encima de 1 que tenga elespacio que hayas empleado. En\r\n el momento deelegirla como objetivo,cada criatura debe\r\n estar a 30 pies o menosde todas las dem�s.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo55
        #region CrearHechizo56
        hechizo = new Hechizo();
        hechizo.Codigo = 56;
        hechizo.Nombre = "Heroismo";
        hechizo.EscuelaMagica = E_EscuelasMagia.ENCANTAMIENTO;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Infundes valor en una criatura voluntaria a la que toques.\r\n Hasta el final del conjuro, no puede ser asustada y gana\r\n tantos puntos de golpe temporales como tu modificador\r\n por aptitud m�gica al principio de cada uno de sus tur\r\nnos.Cuandoel conjuro termina, pierde todos los puntos de\r\n golpe temporales restantes que provengan de este conjuro.\r\n Aniveles superiores. Cuando lanzas este conjuro utili\r\nzando un espacio de conjuro de nivel 2 o m�s, puedes elegir\r\n comoobjetivo a una criatura adicional p'pr cada nivel por\r\n encima de 1 que tenga el espacio que hayasempleado.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo56
        #region CrearHechizo57
        hechizo = new Hechizo();
        hechizo.Codigo = 57;
        hechizo.Nombre = "Identificar";
        hechizo.EscuelaMagica = E_EscuelasMagia.ADIVINACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Una perla que valga, al menos, 100 po");
        hechizo.Componentes.Add("una pluma de b�ho");
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Elige un objeto o criatura ,que deber�s tocar durante el lan\r\nzamiento del conjuro. Si es un objeto m�gico o un objeto\r\n imbuido de magia ,averiguar�s sus propiedades yc�mo\r\n usarlas,si hace falta sintonizarse con �l para utilizarlo y\r\n cu�ntas cargas tiene,si fuera el caso.Si hay conjuros afec\r\ntando al objeto,sabr�s cu�les son.Si elobjeto fue creado\r\n con un conjuro, tambi�n averiguar�s cu� les.\r\n Si tocas una criatura en lugar de un objeto,averiguar�s\r\n qu� conjuros le est�n afectando.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo57
        #region CrearHechizo58
        hechizo = new Hechizo();
        hechizo.Codigo = 58;
        hechizo.Nombre = "Imagen silenciosa";
        hechizo.EscuelaMagica = E_EscuelasMagia.ILUSIONISMO;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Alcance = 60;
        hechizo.RequisitoVocal = false;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Un poco de vell�n");
        hechizo.Duracion = 10;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Creas una imagen de un objeto, una criatura u otro tipo\r\n de fen�menovisible, cuyas dimensiones no excedan las\r\n de un cubo de 15 pies de lado.La imagen aparece en un\r\n sitio que puedas ver dentro del alcance yse mantiene\r\n hasta el final de la duraci�n del conjuro. La imagen es\r\n solamente visual; no est� acompa�ada de sonido, olor u\r\n otros efectos sensoriales.\r\n Mientras est�s dentro del alcance de la ilusi�n, puedes\r\n utilizar tu acci�n para moverla a otro sitio dentro de dicho\r\n alcance. Al cambiarla de sitio, puedes alterar su aparien\r\ncia de forma quesus movimientos parezcan naturales. Por\r\n ejemplo, si creas la imagen de una criatura y la mueves,\r\n puedas alterarla de forma que parezca estar andando.\r\n La interacci�n f�sica con la imagen revela que es una ilu\r\nsi�n, ya que las cosas la atraviesan.Si una criatura emplea\r\n su acci�n para examinar la imagen, puede determinar que\r\n es una ilusi�n si tiene �xito en una prueba de Inteligencia\r\n (Investigaci�n) cuya CD es tu salvaci�n de conjuros. Si la\r\n criatura descubre que la imagen es una ilusi�n, podr� ver a\r\n trav�s de ella.\r\n";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo58
        #region CrearHechizo59
        hechizo = new Hechizo();
        hechizo.Codigo = 59;
        hechizo.Nombre = "Inflingir heridas";
        hechizo.EscuelaMagica = E_EscuelasMagia.NIGROMANCIA;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal =true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Haz una taque deconjuro cuerpoacuerpo contra una cria\r\ntura que se encuentre dentro delalcance .Si impacta, el\r\n objetivo recibe 3d10 de da�o necr�tico.\r\n Anivelessuperiores.Cuandolanzas este conjuro uti\r\nlizando unespacio deconjuro de nivel 2 o m�s ,el da�o\r\n aumenta en Id10 por cada nivel por encima de1que tenga\r\n el espacio que hayas empleado.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo59
        #region CrearHechizo60
        hechizo = new Hechizo();
        hechizo.Codigo = 60;
        hechizo.Nombre = "Maleficio";
        hechizo.EscuelaMagica = E_EscuelasMagia.ENCANTAMIENTO;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION_ADICIONAL;
        hechizo.Alcance = 90;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("El ojo petrificado de un triton");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Impones una maldici�n a una criatura que puedas ver\r\n dentro del alcance. Hasta el final del conjuro ,sufrir� ld �\r\n de da�o necr�tico adicional cada vezque sea impactada\r\n por uno de tus ataques.Adem�s,elige una caracter�stica\r\n cuando lanzas el conjuro. El objetivo tiene desventaja en las\r\n pruebas decaracter�stica ytiradas de salvaci�n hechas con\r\n la caracter�stica elegida.\r\n Si los puntos de golpe del objetivo se reducen a 0 antes\r\n del final de la duraci�n del conjuro ,puedes utilizar una\r\n acci�n adicional en un turno posterior para transferir la\r\n maldici�n a una nuevacriatura.\r\n El conjuro levantar maldici�n termina este conjuro\r\n inmediatamente.\r\n Aniveles superiores.Si utilizas unespacio de conjuro\r\n de nivel 3o 4, la duraci�n pasa a ser:concentraci�n,hasta\r\n 8 horas.Si usas un espacio de conjuro de nivel 5 o m�s, la\r\n duraci�n pasa a ser: concentraci�n, hasta 24 horas.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo60
        #region CrearHechizo61
        hechizo = new Hechizo();
        hechizo.Codigo = 61;
        hechizo.Nombre = "Manos ardientes";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 15;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion =0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = " Juntas las manos con los pulgares toc�ndose y los dedos\r\n estirados, creando una fina capa de llamas que se proyecta\r\n desde la punta de los dedos.Todaslas criaturas en un cono\r\n de 15 pies deben hacer una tirada desalvaci�n de Des\r\ntreza.Sufrir�n 3d6 de da�o de fuegosi fallan la tirada o la\r\n mitad del da�osi la superan.\r\n Losobjetos inflamables que se encuentren en el �rea que\r\n no lleve o vista alguien arder�n.\r\n Anivelessuperiores.Cuandolanzasesteconjuro uti\r\nlizando un espacio de conjuro de nivel 2 o m�s, el da�o\r\n aumenta en ld6 por cada nivel por encima de 1 que tenga\r\n el espacio que hayas empleado.\r\n";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo61
        #region CrearHechizo62
        hechizo = new Hechizo();
        hechizo.Codigo = 62;
        hechizo.Nombre = "Marca del cazador";
        hechizo.EscuelaMagica = E_EscuelasMagia.ADIVINACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION_ADICIONAL;
        hechizo.Alcance = 90;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = false;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = true;
        hechizo.Descripcion = "Eliges una criatura que puedas ver dentro del alcance y\r\n la marcas,de manera m�stica, como tu presa. Hasta que\r\n el conjuro termine, la criatura sufrir� ld� de da�o adicio\r\nnal cuando la impactes con un ataquecon arma y tendr�s\r\n ventaja en cualquier prueba de Sabidur�a (Percepci�n) o\r\n Sabidur�a (Supervivencia) realizada para encontrarla. Si\r\n los puntos de golpe del objetivo se reducen a 0 antes del\r\n final de la duraci�n del conjuro, puedes utilizar una acci�n\r\n adicional en un turno posterior para transferir la marca a\r\n una nueva criatura.\r\n Aniveles superiores. Si empleas un espacio de conjuro\r\n de nivel 3o 4, la duraci�n pasa a ser:concentraci�n, hasta\r\n 8 horas. Si usas un espaciode conjuro de nivel 5o m�s, la\r\n duraci�n pasa a ser:concentraci�n, hasta 24 horas.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo62
        #region CrearHechizo63
        hechizo = new Hechizo();
        hechizo.Codigo = 63;
        hechizo.Nombre = "Nube de oscurecimiento";
        hechizo.EscuelaMagica = E_EscuelasMagia.CONJURACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 120;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.HORA;
        hechizo.Concentracion = true;
        hechizo.Descripcion = " Creas una bruma que cubre un �rea esf�rica de 20 pies de\r\n radio alrededor de un punto de tu elecci�n. La nieblase\r\n extiende m�s all� de las esquinas y el �rea se considera\r\n muy oscura.Se mantiene hasta el final de la duraci�n del\r\n conjuro o hasta que un viento de velocidad moderada (al\r\n menos10 millas por hora) la disperse.\r\n Aniveles superiores. Cuando lanzas este conjuro utili\r\nzando un espacio de conjuro de nivel 2 o m�s, el radio de la\r\n niebla aumenta en 20 pies por cada nivel por encima de 1\r\n que tenga el espacio que hayas empleado.\r\n";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo63
        #region CrearHechizo64
        hechizo = new Hechizo();
        hechizo.Codigo = 64;
        hechizo.Nombre = "Ola atronadora";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 15;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = " Una ola de fuerza atronadora surge de tu cuerpo. Todas las\r\n criaturas en un cubode 15 pies adyacente a ti deben hacer\r\n una tirada de salvaci�n de Constituci�n. Las criaturas que\r\n fallen la tirada^ufrir�n 2d8 de da�o de trueno y ser�n\r\n empujadas 10 pies, y las que la superen sufrir�n la mitad\r\n del da�oy noser�n empujadas.\r\n Adem�s, los objetos dentro del �rea de efecto que nadie\r\n lleve o vista son empujados autom�ticamente 10 pies en\r\n direcci�n contraria a ti. El conjuro crea una explosi�n\r\n s�nica audible a 300 pies de distancia.\r\n Aniveles superiores.Cuando lanzas este conjuro uti\r\nlizando un espacio de conjuro de nivel 2 o m�s, el da�o\r\n aumenta en ld8 por cada nivel por encima de 1que tenga\r\n el espacio que hayasempleado.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo64
        #region CrearHechizo65
        hechizo = new Hechizo();
        hechizo.Codigo = 65;
        hechizo.Nombre = "Orbe cromatico";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 90;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial =true;
        hechizo.Componentes.Add("Un diamante que valga al menos 50 PO");
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = " Lanzas unaesfera de energ�a de 4 pulgadasde di�metroa\r\n una criatura que puedas ver dentro del alcance.Elige entre\r\n �cido, fr�o, fuego, rel�mpago,veneno o trueno para el tipo\r\n de orbe creado y,despu�s, haz un ataque de conjuro a dis\r\ntancia contra el objetivo.Si el ataque impacta, la criatura\r\n recibe 3d8 de da�o del tipo elegido.\r\n Aniveles superiores.Cuando lanzaseste conjuro uti\r\nlizando un espacio de conjuro de nivel 2 o m�s, el da�o\r\n aumenta en ld8por cada nivel por encima de 1 que tenga\r\n el espacio que hayas empleado.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo65
        #region CrearHechizo66
        hechizo = new Hechizo();
        hechizo.Codigo = 66;
        hechizo.Nombre = "Orden imperiosa";
        hechizo.EscuelaMagica = E_EscuelasMagia.ENCANTAMIENTO;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 60;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = false;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.ASALTO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Das una orden de una sola palabra a una criatura que pue\r\ndas ver dentro del alcance. El objetivo debe tener �xito\r\n en una tirada de salvaci�n de Sabidur�a o verse obligada\r\n a obedecer la orden en su pr�ximo turno.Este conjuro\r\n no tiene efecto si el objetivo es un muerto viviente, si no\r\n entiende tu idioma o si la orden implica da�ar a la cria\r\ntura de forma directa.\r\n M�s abajo puedes encontrar ejemplos de �rdenes t�picas\r\n ysus efectos, aunque puedes dar otras distintas a las que\r\n se describen aqu�. En ese caso, el DM decidec�mo reac\r\nciona el objetivo.Si la criatura no puede obedecer la orden,\r\n el conjuro termina.\r\n Ac�rcate. El objetivose acerca a ti por el camino m�s\r\n corto y directo posible, acabando su turno si se mueve a\r\n 5 pies o menosde ti.\r\n Suelta. El objetivo suelta lo que est� sujetando y acaba\r\n su turno.\r\n Huye. El objetivo emplea su turno en alejarse de ti de la\r\n manera m�s r�pida posible.\r\n P�strate. El objetivo cae derribado y acaba su turno.\r\n Detente. El objetivo no se mueve ni realiza ninguna\r\n acci�n. Si le es posible, una criatura que est� volando per\r\nmanecer� en el aire. Si para ello necesita moverse, volar�\r\n la m�nima distancia necesaria para no caer.\r\n Aniveles superiores. Cuando lanzas este conjuro utili\r\nzando un espacio de conjuro de nivel 2 o m�s, puedes elegir\r\n como objetivo a una criatura adicional por cada nivel por encima de 1 que tenga elespacio que hayasempleado. En\r\n el momento de elegirla comoobjetivo, cada criatura debe\r\n estar a 30 pies o menosde todas las dem�s .";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo66
        #region CrearHechizo67
        hechizo = new Hechizo();
        hechizo.Codigo = 67;
        hechizo.Nombre = "Palabra de curacion";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION_ADICIONAL;
        hechizo.Alcance = 60;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = false;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Una criatura de tu elecci�n que puedas ver dentro del\r\n alcance recupera tantos puntos de golpe como lcf4 + tu\r\n modificador por aptitud m�gica. Este conjuro no afecta a\r\n muertos vivientes oaut�matas.\r\n Anivelessuperiores.Cuando lanzas este conjuro utili\r\nzando unespacio deconjuro de nivel 2 o m�s, lacuraci�n\r\n aumenta en ld4 por cada nivel por encima de 1 que tenga\r\n el espacio que hayasempleado.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo67
        #region CrearHechizo68
        hechizo = new Hechizo();
        hechizo.Codigo = 68;
        hechizo.Nombre = "Proteccion contra el bien y el mal";
        hechizo.EscuelaMagica = E_EscuelasMagia.ABJURACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 0;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Agua bendita o plata pulverizada y hierro pulverizados");
        hechizo.Duracion = 10;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = " Hasta el final de la duraci�n del conjuro, una criatura volun\r\ntaria que toques queda protegida contra ciertos tipos de\r\n criaturas: aberraciones, celestiales, elementales, fe�ricos,\r\n infernales y muertos vivientes.\r\n Esta protecci�n proporciona varios beneficios. Las cria\r\nturas del tipo elegido tienen desventaja en tiradas de ataque\r\n contra el objetivo. Este tampoco podr� ser hechizado, asus\r\ntadoo pose�do por ellas.Si el objetivo ya estaba hechizado,\r\n asustado o pose�do por una criatura de este tipo, tendr�\r\n ventaja en cualquier tirada de salvaci�n subsiguiente contra\r\n estos efectos.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo68
        #region CrearHechizo69
        hechizo = new Hechizo();
        hechizo.Codigo = 69;
        hechizo.Nombre = "Proyectil magico";
        hechizo.EscuelaMagica = E_EscuelasMagia.ABJURACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 120;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = " Creas tres dardos brillantes de fuerza m�gica. Cada dardo\r\n impacta a una criatura de tu elecci�n a la que puedas ver\r\n dentro del alcance. La criatura recibe ld4+l de da�o de\r\n fuerza por cada dardo. Todos los dardos impactan a la vez y\r\n puedes repartirlos como desees entre varios objetivos.\r\n Aniveles superiores.Cuando lanzas este conjuro uti\r\nlizando un espacio de conjuro de nivel 2 o m�s, creas un\r\n dardo adicional por cada nivel por encima de 1 que tenga el\r\n espacio que hayas empleado.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo69
        #region CrearHechizo70
        hechizo = new Hechizo();
        hechizo.Codigo = 70;
        hechizo.Nombre = "Purificar comida y agua";
        hechizo.EscuelaMagica = E_EscuelasMagia.TRANSMUTACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 10;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = " Purificas y libras de todo veneno y enfermedad la comida\r\n y bebida no m�gica que est� dentrode una esfera de\r\n 5 pies de radio centrada en un puntode tu elecci�n dentro\r\n del alcance.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo70
        #region CrearHechizo71
        hechizo = new Hechizo();
        hechizo.Codigo = 71;
        hechizo.Nombre = "Rayo de hechiceria";
        hechizo.EscuelaMagica = E_EscuelasMagia.TRANSMUTACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.ACCION;
        hechizo.Alcance = 30;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = true;
        hechizo.Componentes.Add("Una ramita de un arbol que haya sido golpeado por un rayo");
        hechizo.Duracion = 1;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.MINUTO;
        hechizo.Concentracion = true;
        hechizo.Descripcion = " Un rayode energ�a chisporroteante alcanza a una criatura\r\n dentro del alcance, formando un arco constante similar a\r\n un rel�mpago entre el objetivo y t�. Haz un ataque de con\r\njuro a distancia contra la criatura.Si impactas, el objetivo\r\n recibe Id12 de da�ode rel�mpagoy, en cada unode tus\r\n turnos hasta el final de la duraci�n de!conjuro, puedes usar\r\n tu acci�n para infligir autom�ticamente otros Id12 de da�o\r\n de rel�mpagoa la criatura. El conjuro termina si utilizas\r\n tu acci�n para cualquier otra cosa, osi en alg�n momento\r\n el objetivo queda fuera del alcance del conjuro o consigue\r\n tener cobertura completa respecto a ti.\r\n Aniveles superiores.Cuando lanzas este conjuro uti\r\nlizando un espacio de conjuro de nivel 2 o m�s, el da�o\r\n inicial aumenta en Id12 por cada nivel por encima de 1\r\n del espacio.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo71
        #region CrearHechizo72
        hechizo = new Hechizo();
        hechizo.Codigo = 72;
        hechizo.Nombre = "Represion infernal";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.REACCION;
        hechizo.Alcance = 60;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Apuntas con el dedoy la criatura que te da�� seve\r\n envuelta moment�neamenteen una llamarada infernal.\r\n Debe hacer una tirada de salvaci�n de Destreza. '4Sufrir�\r\n 2d10 de da�o de fuego si falla la tirada o la mitad del da�o\r\n si la supera.\r\n Aniveles superiores.Cuando lanzas este conjuro uti\r\nlizando un espacio de conjuro de nivel 2 o m�s,^l da�o\r\n aumenta en Id10 porcada nivel por encima de 1que tenga\r\n el espacio que hayas empleado.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo72
        #region CrearHechizo73
        hechizo = new Hechizo();
        hechizo.Codigo = 73;
        hechizo.Nombre = "Represion infernal";
        hechizo.EscuelaMagica = E_EscuelasMagia.EVOCACION;
        hechizo.Nivel = 1;
        hechizo.Tiempolanzamiento = 1;
        hechizo.TipoLanzamientoHechizo = E_TiempoDeLanzamientoConjuro.REACCION;
        hechizo.Alcance = 60;
        hechizo.RequisitoVocal = true;
        hechizo.RequisitoSomatico = true;
        hechizo.RequisitoMaterial = false;
        hechizo.Duracion = 0;
        hechizo.TipoDuracion = E_TiempoDeLanzamientoConjuro.INSTANTANEO;
        hechizo.Concentracion = false;
        hechizo.Descripcion = "Apuntas con el dedoy la criatura que te da�� seve\r\n envuelta moment�neamenteen una llamarada infernal.\r\n Debe hacer una tirada de salvaci�n de Destreza. '4Sufrir�\r\n 2d10 de da�o de fuego si falla la tirada o la mitad del da�o\r\n si la supera.\r\n Aniveles superiores.Cuando lanzas este conjuro uti\r\nlizando un espacio de conjuro de nivel 2 o m�s,^l da�o\r\n aumenta en Id10 porcada nivel por encima de 1que tenga\r\n el espacio que hayas empleado.";
        hechizo.ClasesAptas.Add(E_Clases.BRUJO);
        hechizos.Add(hechizo);
        #endregion CrearHechizo73
        #endregion Nivel1
        #endregion CrearHechizos


        hechizosFinales.Add(pathload,hechizos);
        return hechizosFinales;
    }

    public Dictionary<string, List<Clase>> CargarClases()
    {
        string pathload = "Assets/Resources/Jsons/ClasesEsp.json";
        List<Clase> clases = new List<Clase>();
        Dictionary<string, List<Clase>> clasesFinales = new Dictionary<string, List<Clase>>();
        clases.Add(new Picaro());

        clasesFinales.Add(pathload, clases);
        return clasesFinales;
    }

    #endregion CargaDatos


    public void PruebaClasePicaro()
    {
       Picaro picaro=new Picaro();
       Debug.Log(picaro.ToString());

        
    }
}
