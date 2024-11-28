using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        LoadListPrueba();
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

    private List<Raza> CargarRazas()
    {
        List<Raza>razas = new List<Raza>();
        Subraza subraza;
        Raza r;
        #region EnanoCreacion
        r = new Raza();
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
        return razas;
    }


    private List<Objeto> CargarObjetos()
    {
        List<Objeto> objectos=new List<Objeto>();
        Objeto objeto;
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
        objeto.Nombre = "Lintera de ojo de buey";
        objeto.SetValor(10);
        objeto.SetPeso(2);
        objeto.SetCantidad(1);
        objeto.TipoValor = E_Monedas.PO;
        objectos.Add(objeto);
        #endregion CrearObjeto51
        #region CrearObjeto52
        objeto = new Objeto();
        objeto.Codigo = 52;
        objeto.Nombre = "Lintera sorda";
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
        return objectos;
    }
    private void LoadListPrueba()
    {
        string pathload = "Assets/Resources/Jsons/RazasEsp.json";
             if (File.Exists(pathload))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(pathload);

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.

            List<Raza> listRazas = JsonConvert.DeserializeObject<List<Raza>>(fileContents);
           
            foreach(Raza r in listRazas)
            {
                //Debug.Log(r.Nombre+":"+r.MejoraCaracteristicas.First().Key.ToString());
                Debug.Log(r.ToString());
            }
           
        }
    }
}
