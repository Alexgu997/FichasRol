using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        LoadListObjetos(CargarObjetos());
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
            atributos.Add(new Atributo("BAJITO PERO MATON", "TAMAÑO REDUCIDO"));
            List<E_Habilidades> habilidades = new List<E_Habilidades>();
            habilidades.Add(E_Habilidades.RELIGION);
            habilidades.Add(E_Habilidades.INTERPRETACION);
            habilidades.Add(E_Habilidades.PERSUASION);
            r.Subraza.Add(new Subraza(E_Subraza.ENANO_DE_LAS_MONTAÑAS, caracteristicas, atributos));
            r.Habilidades = habilidades;
            r.Atributos = atributos;
            // Configurar JsonSerializerSettings para que use nombres de propiedades en minúsculas
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver() // hace que las propiedades empiecen en minúscula
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
        atributos.Add(new Atributo("BAJITO PERO MATON", "TAMAÑO REDUCIDO"));
        List<E_Habilidades>habilidades = new List<E_Habilidades>();
        habilidades.Add(E_Habilidades.RELIGION);
        habilidades.Add(E_Habilidades.INTERPRETACION);
        habilidades.Add(E_Habilidades.PERSUASION);
        r.Subraza.Add(new Subraza(E_Subraza.ENANO_DE_LAS_MONTAÑAS,caracteristicas,atributos));
        r.Habilidades=habilidades;
        r.Atributos=atributos;
        // Configurar JsonSerializerSettings para que use nombres de propiedades en minúsculas
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ContractResolver = new CamelCasePropertyNamesContractResolver() // hace que las propiedades empiecen en minúscula
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
        r.TamañoMinimo = 122;
        r.TamañoMaximo = 152;
        r.Velocidad = 25;
        r.MejoraCaracteristicas.Add(E_Caracteristicas.CONSTITUCION, 2);
        r.Atributos.Add(new Atributo("Visión en la Oscuridad", "Acostumbrado a la vida bajo tierra, puedes ver bien en la oscuridad o con poca luz. Eres capaz de percibir hasta a 60 pies en luz tenue comosi hubiera luz bri llante, y esa misma distancia en la oscuridad como si hubiera luz tenue. Eso sí, no puedes distinguir colores en la oscuridad, solo tonos de gris."));
        r.Atributos.Add(new Atributo("Resistencia Enana", "Tienes ventaja en las tiradas de salvación contra veneno y posees resistencia al daño de veneno"));
        r.Atributos.Add(new Atributo("Entrenamientode Combate Enano", "Eres competente con hachas de guerra, hachasde mano, martillos de guerra y martillos ligeros."));
        r.Atributos.Add(new Atributo("Competencia con Herramientas", "Eres competente con las herramientas de artesano que elijas de entre las siguientes:herramientas de albañil, herramientas de herrero o suministros de cervecero"));
        r.Atributos.Add(new Atributo("Afinidad con la Piedra", "Cuando hagas una prueba de Inteligencia (Historia) que tenga relación con el origen de un trabajo en piedra, se te considerará competente en la habilidad Historia y añadirás dos veces tu bonificador por competencia a la tirada, en lugar de solo una"));
        r.Atributos.Add(new Atributo("Idiomas", "Puedes hablar, leer y escribir en común y enano. El idioma enano está lleno de consonantes duras y sonidos guturales, y estas peculiaridades se traslucen en la forma que tienen losenanos de pronunciar cualquier otro lenguaje que conozcan"));
        #region SubrazasEnanosCreacion
        subraza= new Subraza();
        subraza.Nombre = E_Subraza.ENANO_DE_LAS_COLINAS;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.SABIDURIA, 1);
        subraza.Rasgos.Add(new Atributo("Aguante Enano", "Tus puntos de golpe máximosse incrementan en 1, y aumentarán en 1 más cada vez que subas un nivel."));
        r.Subraza.Add(subraza);
        subraza = new Subraza();
        subraza.Nombre = E_Subraza.ENANO_DE_LAS_MONTAÑAS;
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
        r.TamañoMinimo = 152;
        r.TamañoMaximo = 183;
        r.Velocidad = 30;
        r.MejoraCaracteristicas.Add(E_Caracteristicas.DESTREZA, 2);
        r.Atributos.Add(new Atributo("Visión en la Oscuridad", "Acostumbrado a la penumbra de los bosques y el cielo nocturno, puedes ver bien en la oscuridad o con poca luz. Hasta a un máximo de 60 pies, eres capaz de ver con luz tenue comosi hubiera luz brillante y en la oscuridad como si hubiera luz tenue. Eso sí, no puedes distinguir colores en la oscuridad, solo tonos de gris."));
        r.Atributos.Add(new Atributo("Sentidos Agudos", "Eres competente en la habilidad Percepción"));
        r.Atributos.Add(new Atributo("Linaje Feérico", "Tienes ventaja en las tiradas de salvación para evitar ser hechizado y la magia no puede dormirte."));
        r.Atributos.Add(new Atributo("Trance", "Los elfos no necesitan dormir. Meditan profundamente, en un estado semiconsciente,durante 4 horas al día. La palabra en común para referirse a esta meditación es “trance”. Mientras meditas, experimentas algo parecido a sueños,que en realidad son ejercicios mentales que se han vuelto automáticos tras años de práctica. Este trance es suficiente para obtener los mismos beneficios que un humano recibe de 8 horas de sueño"));
        r.Atributos.Add(new Atributo("Idiomas", "Puedes hablar, leer y escribir en común y elfo. El idioma elfo es fluido, con entonaciones sutiles y una gramática compleja. La literatura élfica es rica y variada, y sus canciones y poemas son famosos entre el resto de razas. Muchos bardos aprenden este idioma para poder añadir baladas élficas asus repertorios."));
        r.Habilidades.Add(E_Habilidades.PERCEPCION);
        #region SubrazasELfosCreacion
        subraza = new Subraza();
        subraza.Nombre = E_Subraza.ALTO_ELFO;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.INTELIGENCIA, 1);
        subraza.Rasgos.Add(new Atributo("Entrenamiento con Armas Elficas", "Eres competente con espadas cortas, espadas largas, arcos cortos y arcos largos."));
        subraza.Rasgos.Add(new Atributo("Truco", "Conoces un truco de tu elección escogido de entre los de la lista de conjuros de mago. La Inteligencia es tu aptitud mágica para lanzarlo."));
        subraza.Rasgos.Add(new Atributo("Idioma Adicional", "Puedes hablar, leer y escribir un idioma adicional de tu elección."));

        r.Subraza.Add(subraza);
        subraza = new Subraza();
        subraza.Nombre = E_Subraza.ELFO_DE_LOS_BOSQUES;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.SABIDURIA,1);
        subraza.Rasgos.Add(new Atributo("Entrenamiento con Armas Élfícas", "Eres competente con espadas cortas, espadas largas, arcos cortos y arcos largos."));
        subraza.Rasgos.Add(new Atributo("Pies Veloces", "Tu velocidad caminando base aumenta a 35 pies."));
        subraza.Rasgos.Add(new Atributo(" Máscara de la Naturaleza", "Puedes intentar esconderte incluso cuando estés en un lugar solo ligeramente oscuro, siempre que lo que te tape sea follaje, una lluvia fuerte, nieve que cae, niebla o cualquier otro fenómeno natural."));

        r.Subraza.Add(subraza);
        subraza = new Subraza();
        subraza.Nombre = E_Subraza.DROW;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.CARISMA, 1);
        subraza.Rasgos.Add(new Atributo("Visión en la Oscuridad Superior", "Tu visión en la oscuridad posee un radio de 120 pies."));
        subraza.Rasgos.Add(new Atributo("Sensibilidad a la Luz Solar", "Tienes desventaja en las tiradas de ataque y las pruebas de Sabiduría (Percepción) que dependan de la vista realizadas cuando tú, el objetivo de tu ataque o lo que sea que intentas percibir esté bajo la luz solar directa."));
        subraza.Rasgos.Add(new Atributo("Magia Drow", "Conoces el truco luces danzantes. Cuando llegas a nivel 3, puedes lanzar el conjuro fuego feérico una vez usando este atributo y recuperas la capacidad para hacerlo tras realizar un descanso largo. Cuando alcanzasel nivel 5, eres capaz de lanzar el conjuro oscuridad una vez empleando este atributo y recuperas la capacidad para hacerlo tras realizar un descanso largo. El Carisma es tu aptitud mágica para estos conjuros."));
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
        r.TamañoMinimo = 91;
        r.TamañoMaximo = 93;
        r.Velocidad = 25;
        r.MejoraCaracteristicas.Add(E_Caracteristicas.DESTREZA, 2);
        r.Atributos.Add(new Atributo("Afortunado", "Cuando saques un 1 en el dado al hacer una tirada de ataque, prueba de característica o tirada de salvación, puedes volver a tirar el dado, pero tendrás que utilizar el resultado nuevo."));
        r.Atributos.Add(new Atributo("Valiente", "Posees ventaja en las tiradas de salvación para evitar ser asustado."));
        r.Atributos.Add(new Atributo("Agilidad de Mediano", "Puedes movertea través del espacio ocupado por una criatura cuyo tamaño sea, al menos, una categoría superior al tuyo."));
        r.Atributos.Add(new Atributo("Idiomas", "Puedes hablar, leer y escribir en común y mediano.El idioma de los medianos no es secreto, pero estos son reticentes a compartirlo con otros. Escriben poco, por lo que no tienen una gran producción literaria. No obstante, su tradición oral es muy rica. Prácticamente todos los medianos hablan común para poder comunicarse con losque viven junto a ellos o en los lugares por los que viajan."));
        #region SubrazasMedianosCreacion
        subraza = new Subraza();
        subraza.Nombre = E_Subraza.PIESLIGEROS;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.CARISMA, 1);
        subraza.Rasgos.Add(new Atributo("Sigiloso por Naturaleza", "Puedes intentar esconderte incluso tras una criatura cuyo tamaño sea, al menos, una categoría superior al tuyo."));
        
        r.Subraza.Add(subraza);


        subraza = new Subraza();
        subraza.Nombre = E_Subraza.FORNIDO;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.CONSTITUCION, 1);
        subraza.Rasgos.Add(new Atributo("Resistencia de Fornido", "Tienes ventaja en las tiradas de salvación contra veneno y posees resistencia al daño de veneno."));
        r.Subraza.Add(subraza);
        #endregion SubrazasMedianosCreacion
        razas.Add(r);
        #endregion  MedianoCreacion
        #region HumanoCreacion
        r = new Raza();
        r.Codigo = 4;
        r.Nombre = E_Razas.HUMANO;
        r.EdadMaxima = 90;
        r.TamañoMinimo = 152;
        r.TamañoMaximo = 183;
        r.Velocidad = 30;
        r.MejoraCaracteristicas.Add(E_Caracteristicas.FUERZA, 1);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.DESTREZA, 1);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.CONSTITUCION, 1);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.INTELIGENCIA,1);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.SABIDURIA,1);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.CARISMA, 1);


        r.Atributos.Add(new Atributo("Idiomas", "Idiomas\", \"Puedes hablar, leer y escribir común y un idioma adicional de tu elección. Los humanos normalmente aprenden los idiomas de aquellos con los que se relacionan, aunque sean dialectos poco conocidos. Les gusta adornar su habla con palabras tomadas de otras lenguas: maldiciones oreas, expresiones musicales elfas, términos militares enanos, y así."));
        razas.Add(r);
        #endregion  HumanoCreacion
        #region DraconianoCreacion
        r = new Raza();
        r.Codigo = 5;
        r.Nombre = E_Razas.DRACONICO;
        r.EdadMaxima = 80;
        r.TamañoMinimo = 183;
        r.TamañoMaximo = 213;
        r.Velocidad = 30;
        r.Alienamiento = E_Alienamiento.BUENO;
        r.MejoraCaracteristicas = new Dictionary<E_Caracteristicas, int>();
        r.MejoraCaracteristicas.Add(E_Caracteristicas.FUERZA, 2);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.CARISMA, 1);

        r.Atributos = new List<Atributo>();
        r.Atributos.Add(new Atributo("Linaje Dracónico", "Posees la sangre de dragones. Escoge de qué tipoen la tabla “linaje dracónico”. Tu Ataque de Aliento y Resistencia al Daño vendrán determinadas por el tipo de dragón, tal y como se indica en dicha tabla."));
        r.Atributos.Add(new Atributo("Ataque de Aliento", "Puedes utilizar tu acción para exhalar energía destructora. Tu Linaje Dracónico determina el tamaño, forma y tipo de daño del aliento. Cuando uses tu Ataque de Aliento, las criaturas que se encuentren en la zona cubierta por este deberán hacer una tirada de salvación, cuyo tipo viene definido por tu linaje. La CD de esta tirada de salvación es de 8 + tu modificador por Constitución + tu bonilicador por competencia. Las criaturas sufrirán 2d6 de daño si fallan la tirada o la mitad de ese daño si la superan. El daño aumenta a 3d6 cuando alcanzas el nivel 6, a 4d6 a nivel 11 y a 5d6 a nivel 16. Una vez utilizado el Ataque de Aliento, no podrás volver a emplearlo hasta que finalices un descanso corto o largo."));
        r.Atributos.Add(new Atributo("Resistencia al Daño", "Posees resistencia al tipo de daño asociado a tu Linaje Dracónico."));
        r.Atributos.Add(new Atributo("Idiomas", "Puedes hablar, leer y escribir en común y dracónico. Se piensa que el dracónico es uno de los idiomas más antiguos y suele emplearse en el estudio de la magia. Resulta áspero a oídos de la mayoría de criaturas y utiliza muchas consonantes duras y sibilantes."));
        razas.Add(r);
        #endregion  DraconianoCreacion
        #region GnomoCreacion
        r = new Raza();
        r.Codigo = 6;
        r.Nombre = E_Razas.GNOMO;
        r.EdadMaxima = 500;
        r.TamañoMinimo = 92;
        r.TamañoMaximo = 122;
        r.Velocidad = 25;
        r.Alienamiento = E_Alienamiento.BUENO;
        r.MejoraCaracteristicas = new Dictionary<E_Caracteristicas, int>();
        r.MejoraCaracteristicas.Add(E_Caracteristicas.INTELIGENCIA, 2);
        #region SubrazasGnomoCreacion
        subraza = new Subraza();
        subraza.Nombre = E_Subraza.GNOMO_DE_LOS_BOSQUES;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.DESTREZA, 1);
        subraza.Rasgos.Add(new Atributo("Ilusionista Innato", "Conoces el truco ilusión menor. La Inteligencia es tu aptitud mágica para lanzarlo."));
        subraza.Rasgos.Add(new Atributo("Hablar con las Bestezuelas", "Puedes comunicar ideas sencillas a bestias de tamaño Pequeño o inferior usando gestos y sonidos. Los gnomos de los bosques adoran a los animales y en ocasiones adoptan ardillas, tejones, conejos, topos, pájaros carpinteros y otras criaturas similares como mascotas."));
        r.Subraza.Add(subraza);
        subraza = new Subraza();
        subraza.Nombre = E_Subraza.GNOMO_DE_LAS_ROCAS;
        subraza.MejoraCaracteristicas.Add(E_Caracteristicas.CONSTITUCION, 1);
        subraza.Rasgos.Add(new Atributo("Saber del Artificiero", "Conoces el truco ilusión menor. La Inteligencia es tu aptitud mágica para lanzarlo."));
        subraza.Rasgos.Add(new Atributo("Manilas", "Eres competente con las siguientes herramientas de artesano: herramientasde manitas. Usándolas,puedes invertir 1 hora y materiales valorados en 10 po para construir un dispositivo de relojería de tamaño Diminuto(CA 5,1 punto de golpe).Este dispositivo deja de funcionar pasadas 24 horas(salvo si dedicas 1 hora a repararlo para mantenerlo a punto) o si usas una acción para desmantelarlo. De hacer esto último, puedes recuperar los materiales que usaste en la construcción. Puedes tener hasta tres dispositivos de este tipo funcionando al mismo tiempo. Cada vez que construyas un dispositivo, elige de entre las siguientes opciones: Juguete de relojería. Este juguete mecánico posee forma de un animal,monstruo o persona. Como,por ejemplo, de una rana,un ratón,un dragóno un soldado. Tras depositarlo en el suelo, se moverá 5 pies en una dirección aleatoria en cada uno de tus turnos.Hace ruidos apropiados para el ser que representa. Encendedor. Este dispositivo produce una llama en miniatura, que puedes utilizar para encder una vela, antorcha u hoguera. Para usarlo es necesario invertir una acción. Caja de música. Al abrirse, esta caja de música reproduce una única canción a un volumen moderado. La caja deja de sonar cuando la canción se acaba o es cerrada."));
        r.Subraza.Add(subraza);
        #endregion SubrazasGnomoCreacion
        r.Atributos.Add(new Atributo("Visión en la Oscuridad.", "Acostumbrado a la vida bajo tierra, puedes ver bien en la oscuridad o con poca luz. Eres capaz de percibir hasta a 60 pies en luz tenue como si hubiera luz brillante, y esa misma distancia enla oscuridad como si hubiera luz tenue. Eso sí, no puedes distinguir colores en la oscuridad, solo tonos de gris."));
        r.Atributos.Add(new Atributo("Astucia Gnoma", "Tienes ventaja en las tiradas de salvación de Inteligencia, Sabiduría y Carisma contra magia."));
        r.Atributos.Add(new Atributo("Idiomas", "Puedes hablar, leer y escribir en común y gnomo. El idioma gnomo, que se escribe con el alfabeto enano, es famoso por la cantidad de tratados técnicos y catálogos de conocimiento sobre el mundo natural escritos en él."));

        razas.Add(r);
        #endregion  GnomoCreacion
        #region SemiElfoCreacion
        r = new Raza();
        r.Codigo = 7;
        r.Nombre = E_Razas.SEMIELFO;
        r.EdadMaxima = 180;
        r.TamañoMinimo = 152;
        r.TamañoMaximo = 183;
        r.Velocidad = 30;
        r.Alienamiento = E_Alienamiento.CAOTICO;
        r.MejoraCaracteristicas = new Dictionary<E_Caracteristicas, int>();
        r.MejoraCaracteristicas.Add(E_Caracteristicas.CARISMA, 1);
        
        r.Atributos.Add(new Atributo("Visión en la Oscuridad.", "Debido a tu sangre élfica, puedes ver bien en la oscuridad o con poca luz. Eres capaz de percibir hasta a 60 pies en luz tenue como si hubiera luz brillante, y esa misma distancia en la oscuridad como si hubiera luz tenue. Eso sí, no puedes distinguir coloresen la oscuridad, solo tonos de gris."));
        r.Atributos.Add(new Atributo("Linaje Feérico", "Tienes ventaja en las tiradas de salvación para evitar ser hechizado y la magia no puede dormirte."));
        r.Atributos.Add(new Atributo("Versátil con Habilidades", "Ganas competencia en dos habilidades de tu elección."));
        r.Atributos.Add(new Atributo("Idiomas", "Puedes hablar, leer y escribir común, elfo y un idioma adicional de tu elección."));
        razas.Add(r);
        #endregion  SemiElfoCreacion
        #region SemiOrcoCreacion
        r = new Raza();
        r.Codigo = 8;
        r.Nombre = E_Razas.SEMIORCO;
        r.EdadMaxima = 75;
        r.TamañoMinimo = 152;
        r.TamañoMaximo = 183;
        r.Velocidad = 30;
        r.Alienamiento = E_Alienamiento.CAOTICO;
        r.MejoraCaracteristicas= new Dictionary<E_Caracteristicas, int>();
        r.MejoraCaracteristicas.Add(E_Caracteristicas.FUERZA, 2);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.CONSTITUCION, 1);

        r.Atributos = new List<Atributo>();
        r.Atributos.Add(new Atributo("Visión en la Oscuridad.", "Debido a tu sangre orca, puedes ver bien en la oscuridad o con poca luz. Eres capaz de percibir hasta a 60 pies en luz tenue comosi hubiera luz brillante, y esa misma distancia en la oscuridad como si hubiera luz tenue. Eso sí, no puedes distinguir colores en la oscuridad, solo tonos de gris."));
        r.Atributos.Add(new Atributo("Amenazador", "Eres competente en la habilidad Intimidación."));
        r.Atributos.Add(new Atributo("Aguante Incansable", "Cuando tus puntos de golpe se reducen a 0 pero no mueres instantáneamente, puedes volver a tener 1 punto de golpe. Una vez utilizado este atributo, deberás terminar un descanso largo para poder volver a usarlo otra vez."));
        r.Atributos.Add(new Atributo("Ataques Salvajes", "Cuando hagas un crítico con un ataque con arma cuerpo a cuerpo, podrás tirar uno de los dados de daño del arma una vez más y añadir el resultado al daño adicional causado por el crítico"));
        r.Atributos.Add(new Atributo(" Idiomas", "Puedes hablar, leer y escribir en común y orco. El orco es un idioma áspero y severo, con consonantes duras. No tiene escritura propia, pero para transcribirlo se usa el alfabeto enano."));
        razas.Add(r);

        #endregion  SemiOrcoCreacion
        #region TieflingCreacion
        r = new Raza();
        r.Codigo = 9;
        r.Nombre = E_Razas.TIEFLING;
        r.EdadMaxima = 100;
        r.TamañoMinimo = 152;
        r.TamañoMaximo = 183;
        r.Velocidad = 30;
        r.Alienamiento = E_Alienamiento.MALVADO;
        r.MejoraCaracteristicas = new Dictionary<E_Caracteristicas, int>();
        r.MejoraCaracteristicas.Add(E_Caracteristicas.CARISMA, 2);
        r.MejoraCaracteristicas.Add(E_Caracteristicas.INTELIGENCIA, 1);

        r.Atributos.Add(new Atributo("Visión en la Oscuridad.", "Debido a tu sangre infernal, puedes ver bien en la oscuridad o con poca luz. Eres capaz de percibir hasta a 60 pies en luz tenue como si hubiera luz brillante, y esa misma distancia en la oscuridad como si hubiera luz tenue. Eso sí, no puedes distinguir colores en la oscuridad, solo tonos de gris"));
        r.Atributos.Add(new Atributo("Resistencia Infernal", " Posees resistencia al daño de fuego."));
        r.Atributos.Add(new Atributo("Linaje Infernal", "Conoces el truco taumaturgia. Cuando llegas a nivel 3, puedes lanzar el conjuro reprensión infernal como conjuro de nivel 2 una vez usando este atributo y recuperas la capacidad para hacerlo tras realizar un descanso largo. Cuando alcanzas el nivel 5, eres capaz de lanzar el conjuro oscuridad una vez empleando este atributo y recuperas la capacidad para hacerlo tras realizar un descanso largo. El Carismaes tu aptitud mágica para estos conjuros."));
        r.Atributos.Add(new Atributo("Idiomas", "Puedes hablar, leery escribir en común e infernal."));
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
        objeto.Nombre = "Tótem";
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
        objeto.Nombre = "Caña de pescar";
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
        objeto.Nombre = "Cuerda de cañamo";
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D6;
        arma.AñadirPropiedad(E_Propiedades.CONTUNDENTE);
        arma.AñadirPropiedad(E_Propiedades.VERSATIL);
        arma.CantidadSegundoDaño = 1;
        arma.TipoDadoSegundoDaño = E_TiposDados.D8;
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D4;
        arma.AñadirPropiedad(E_Propiedades.CORTANTE);
        arma.AñadirPropiedad(E_Propiedades.ARROJADIZA);
        arma.AñadirPropiedad(E_Propiedades.LIGERA);
        arma.AñadirPropiedad(E_Propiedades.SUTIL);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D4;
        arma.AñadirPropiedad(E_Propiedades.CONTUNDENTE);
        arma.AñadirPropiedad(E_Propiedades.LIGERA);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D8;
        arma.AñadirPropiedad(E_Propiedades.CONTUNDENTE);
        arma.AñadirPropiedad(E_Propiedades.A_DOS_MANOS);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D6;
        arma.AñadirPropiedad(E_Propiedades.CORTANTE);
        arma.AñadirPropiedad(E_Propiedades.ARROJADIZA);
        arma.AñadirPropiedad(E_Propiedades.ALCANCE);
        arma.AñadirPropiedad(E_Propiedades.LIGERA);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D4;
        arma.AñadirPropiedad(E_Propiedades.CORTANTE);
        arma.AñadirPropiedad(E_Propiedades.LIGERA);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D6;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
        arma.AñadirPropiedad(E_Propiedades.ARROJADIZA);
        arma.AñadirPropiedad(E_Propiedades.ALCANCE);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D6;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
        arma.AñadirPropiedad(E_Propiedades.ARROJADIZA);
        arma.AñadirPropiedad(E_Propiedades.ALCANCE);
        arma.SetAlcance(20, 60);
        arma.AñadirPropiedad(E_Propiedades.VERSATIL);
        arma.CantidadSegundoDaño = 1;
        arma.TipoDadoSegundoDaño = E_TiposDados.D8;
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D4;
        arma.AñadirPropiedad(E_Propiedades.CONTUNDENTE);
        arma.AñadirPropiedad(E_Propiedades.ARROJADIZA);
        arma.AñadirPropiedad(E_Propiedades.ALCANCE);
        arma.SetAlcance(20, 60);
        arma.AñadirPropiedad(E_Propiedades.LIGERA);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D6;
        arma.AñadirPropiedad(E_Propiedades.CONTUNDENTE);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D6;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
        arma.AñadirPropiedad(E_Propiedades.MUNICION);
        arma.AñadirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.AñadirPropiedad(E_Propiedades.ALCANCE);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D8;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
        arma.AñadirPropiedad(E_Propiedades.MUNICION);
        arma.AñadirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.AñadirPropiedad(E_Propiedades.ALCANCE);
        arma.AñadirPropiedad(E_Propiedades.RECARGA);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D4;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
        arma.AñadirPropiedad(E_Propiedades.SUTIL);
        arma.AñadirPropiedad(E_Propiedades.ARROJADIZA);
        arma.AñadirPropiedad(E_Propiedades.ALCANCE);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D4;
        arma.AñadirPropiedad(E_Propiedades.CONTUNDENTE);
        arma.AñadirPropiedad(E_Propiedades.SUTIL);
        arma.AñadirPropiedad(E_Propiedades.MUNICION);
        arma.AñadirPropiedad(E_Propiedades.ALCANCE);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D10;
        arma.AñadirPropiedad(E_Propiedades.CORTANTE);
        arma.AñadirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.AñadirPropiedad(E_Propiedades.GRAN_ALCANCE);
        arma.AñadirPropiedad(E_Propiedades.PESADA);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D6;
        arma.AñadirPropiedad(E_Propiedades.CORTANTE);
        arma.AñadirPropiedad(E_Propiedades.LIGERA);
        arma.AñadirPropiedad(E_Propiedades.SUTIL);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D6;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
        arma.AñadirPropiedad(E_Propiedades.LIGERA);
        arma.AñadirPropiedad(E_Propiedades.SUTIL);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D8;
        arma.AñadirPropiedad(E_Propiedades.CORTANTE);
        arma.AñadirPropiedad(E_Propiedades.VERSATIL);
        arma.CantidadSegundoDaño = 1;
        arma.TipoDadoSegundoDaño= E_TiposDados.D10;
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
        arma.CantidadDaño = 2;
        arma.TipoDadoDaño = E_TiposDados.D8;
        arma.AñadirPropiedad(E_Propiedades.CORTANTE);
        arma.AñadirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.AñadirPropiedad(E_Propiedades.PESADA);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D8;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
        arma.AñadirPropiedad(E_Propiedades.SUTIL);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D8;
        arma.AñadirPropiedad(E_Propiedades.CONTUNDENTE);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D10;
        arma.AñadirPropiedad(E_Propiedades.CORTANTE);
        arma.AñadirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.AñadirPropiedad(E_Propiedades.GRAN_ALCANCE);
        arma.AñadirPropiedad(E_Propiedades.PESADA);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D12;
        arma.AñadirPropiedad(E_Propiedades.CORTANTE);
        arma.AñadirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.AñadirPropiedad(E_Propiedades.GRAN_ALCANCE);
        arma.AñadirPropiedad(E_Propiedades.PESADA);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D8;
        arma.AñadirPropiedad(E_Propiedades.CORTANTE);
        arma.AñadirPropiedad(E_Propiedades.VERSATIL);
        arma.CantidadSegundoDaño = 1;
        arma.TipoDadoSegundoDaño= E_TiposDados.D10;
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D12;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
        arma.AñadirPropiedad(E_Propiedades.GRAN_ALCANCE);
        arma.AñadirPropiedad(E_Propiedades.ESPECIAL);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D4;
        arma.AñadirPropiedad(E_Propiedades.CORTANTE);
        arma.AñadirPropiedad(E_Propiedades.GRAN_ALCANCE);
        arma.AñadirPropiedad(E_Propiedades.SUTIL);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D8;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D8;
        arma.AñadirPropiedad(E_Propiedades.CONTUNDENTE);
        arma.AñadirPropiedad(E_Propiedades.VERSATIL);
        arma.CantidadSegundoDaño = 1;
        arma.TipoDadoSegundoDaño = E_TiposDados.D10;
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
        arma.CantidadDaño = 2;
        arma.TipoDadoDaño = E_TiposDados.D6;
        arma.AñadirPropiedad(E_Propiedades.CONTUNDENTE);
        arma.AñadirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.AñadirPropiedad(E_Propiedades.PESADA);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D10;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
        arma.AñadirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.AñadirPropiedad(E_Propiedades.GRAN_ALCANCE);
        arma.AñadirPropiedad(E_Propiedades.PESADA);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D8;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D6;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
        arma.AñadirPropiedad(E_Propiedades.ARROJADIZA);
        arma.AñadirPropiedad(E_Propiedades.ALCANCE);
        arma.SetAlcance(20, 60);
        arma.AñadirPropiedad(E_Propiedades.VERSATIL);
        arma.CantidadSegundoDaño = 1;
        arma.TipoDadoSegundoDaño = E_TiposDados.D8;
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D8;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
        arma.AñadirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.AñadirPropiedad(E_Propiedades.MUNICION);
        arma.AñadirPropiedad(E_Propiedades.PESADA);
        arma.AñadirPropiedad(E_Propiedades.ALCANCE);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D6;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
        arma.AñadirPropiedad(E_Propiedades.RECARGA);
        arma.AñadirPropiedad(E_Propiedades.MUNICION);
        arma.AñadirPropiedad(E_Propiedades.LIGERA);
        arma.AñadirPropiedad(E_Propiedades.ALCANCE);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D10;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
        arma.AñadirPropiedad(E_Propiedades.A_DOS_MANOS);
        arma.AñadirPropiedad(E_Propiedades.RECARGA);
        arma.AñadirPropiedad(E_Propiedades.MUNICION);
        arma.AñadirPropiedad(E_Propiedades.PESADA);
        arma.AñadirPropiedad(E_Propiedades.ALCANCE);
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
        arma.CantidadDaño = 1;
        arma.TipoDadoDaño = E_TiposDados.D4;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
        arma.AñadirPropiedad(E_Propiedades.RECARGA);
        arma.AñadirPropiedad(E_Propiedades.MUNICION);
        arma.AñadirPropiedad(E_Propiedades.ALCANCE);
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
        arma.CantidadDaño = 0;
        arma.TipoDadoDaño = E_TiposDados.D4;
        arma.AñadirPropiedad(E_Propiedades.PERFORANTE);
        arma.AñadirPropiedad(E_Propiedades.ARROJADIZA);
        arma.AñadirPropiedad(E_Propiedades.ESPECIAL);
        arma.AñadirPropiedad(E_Propiedades.ALCANCE);
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
        objetosFinales.Add(pathload, objectos);
        return objetosFinales;
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
           
            foreach(object obj in listObjects)
            {
                //Debug.Log(r.Nombre+":"+r.MejoraCaracteristicas.First().Key.ToString());
                Debug.Log(obj.ToString());
            }
           
        }
    }

    private void LoadListObjetos(Dictionary<string, List<Objeto>> jsonObjetosPorGuardar)
    {
        string pathload = jsonObjetosPorGuardar.Keys.First();
        if (File.Exists(pathload))
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
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            settings.Converters.Add(new StringEnumConverter());
            Debug.Log(jsonObjetosPorGuardar.Values.First().Count());
            jsonObjetosPorGuardar.Values.First().ForEach(objeto => { Debug.Log(objeto.Nombre); });

            string jsonString = JsonConvert.SerializeObject(jsonObjetosPorGuardar.Values.First(), settings);

            File.WriteAllText(pathload, jsonString);
        }
    }

}
