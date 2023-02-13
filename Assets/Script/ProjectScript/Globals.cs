using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item {
    string _name;
    Color32 _color;

    public item(string name, Color32 color) {
        _name = name;
        _color = color;
    }
    public string name { get => _name; }
    public Color32 color { get => _color; }
}

public class assessment1 {
    string _question;
    string _option1, _option2, _option3, _option4;
    int _correctAnswer;
    int _Lattice;

    public assessment1 (string q, string o1, string o2, string o3, string o4, int ans, int g) {
            _question = q;
            _option1 = o1; _option2 = o2; _option3 = o3; _option4 = o4;
            _correctAnswer = ans;
            _Lattice = g;
        }
        public string question { get => _question; }
        public string option1 { get => _option1; }
        public string option2 { get => _option2; }
        public string option3 { get => _option3; }
        public string option4 { get => _option4; }
        public int correctAnswer { get => _correctAnswer; }
        public int Lattice { get => _Lattice; }
}

public class assessment2 {
    string _question;
    int _option1, _option2, _option3, _option4;
    int _correctAnswer;

    public assessment2 (string q, int o1, int o2, int o3, int o4, int ans) {
            _question = q;
            _option1 = o1; _option2 = o2; _option3 = o3; _option4 = o4;
            _correctAnswer = ans;
        }
        public string question { get => _question; }
        public int option1 { get => _option1; }
        public int option2 { get => _option2; }
        public int option3 { get => _option3; }
        public int option4 { get => _option4; }
        public int correctAnswer { get => _correctAnswer; }
}

public class Globals
{
    public static int ENDQUESTIONS1 = 7;
    public static int ENDQUESTIONS2 = 7;
    public static int ENDQUESTIONS3 = 7;
    public static item[] SimpleCubePo = new item[]
    {
        new item("Po", new Color32 (183, 231, 149, 255))
    };

    public static item[] SimpleCubeSalt = new item[]
    {
        new item("Na", new Color32 (187, 216, 219, 255)), 
        new item("Cl", new Color32 (187, 209, 219, 255))
    };
    public static item[] bcc = new item[]
    {
        new item("Li", new Color32 (187, 216, 219, 255)),
        new item("Na", new Color32 (187, 216, 219, 255)),
        new item("K", new Color32 (187, 216, 219, 255)),
        new item("V", new Color32 (207, 187, 219, 255)),
        new item("Cr", new Color32 (207, 187, 219, 255)),
        new item("Fe", new Color32 (207, 187, 219, 255)),
        new item("Rb", new Color32 (187, 216, 219, 255)),
        new item("Nb", new Color32 (207, 187, 219, 255)),
        new item("Mo", new Color32 (207, 187, 219, 255)),
        new item("Cs", new Color32 (187, 216, 219, 255)),
        new item("Ba", new Color32 (219, 193, 187, 255)),
        new item("Eu", new Color32 (200, 159, 112, 255)),
        new item("Ta", new Color32 (207, 187, 219, 255)),
        new item("W", new Color32 (207, 187, 219, 255))
    };
    public static item[] fcc = new item[]
    {
        new item("Al", new Color32 (183, 231, 149, 255)),
        new item("Ca", new Color32 (219, 193, 187, 255)),
        new item("Ni", new Color32 (207, 187, 219, 255)), 
        new item("Co", new Color32 (207, 187, 219, 255)),
        new item("Sr", new Color32 (219, 193, 187, 255)),
        new item("Rh", new Color32 (207, 187, 219, 255)),
        new item("Pd", new Color32 (207, 187, 219, 255)),
        new item("Ag", new Color32 (207, 187, 219, 255)),
        new item("Yb", new Color32 (138, 202, 200, 255)),
        new item("Ir", new Color32 (207, 187, 219, 255)),
        new item("Pt", new Color32 (207, 187, 219, 255)),
        new item("Au", new Color32 (207, 187, 219, 255)),
        new item("Pb", new Color32 (183, 231, 149, 255)),
        new item("Ac", new Color32 (219, 193, 187, 255))
    };
    public static item[] fccDiamond = new item[]
    {
        new item("C", new Color32 (187, 200, 219, 255)), 
        new item("Si", new Color32 (223, 226, 173, 255)),
        new item("Ge", new Color32 (223, 226, 173, 255)),
        new item("Sn", new Color32 (223, 226, 172, 255))
    };
    public static item[] fccZincblende = new item[]
    {
        new item("C", new Color32 (187, 200, 219, 255)), 
        new item("Si", new Color32 (223, 226, 173, 255)),
        new item("S", new Color32 (187, 216, 219, 255)),
        new item("Zn", new Color32 (207, 187, 219, 255))
    };
    public static item[] bccCSCL = new item[]
    {};

    public static assessment1[] q1 = new assessment1[] 
    {
        new assessment1 ("What is the crystal name for the atomic structure shown?", "FCC salt", "Simple cubic (polonium)", "FCC sub group (Diamond)", "FCC (Nickel)", 1, 0),
        new assessment1 ("What is the crystal name for the atomic structure shown?", "BCC (Iron)", "FCC (Nickel)", "FCC sub group (Diamond)", "Simple cubic (polonium)", 0, 1),
        new assessment1 ("What is the crystal name for the atomic structure shown?", "Simple cubic (polonium)", "FCC salt", "FCC (Nickel)", "FCC sub group (Diamond)", 2, 2),
        new assessment1 ("What is the crystal name for the atomic structure shown?", "BCC (IRon)", "FCC (Nickel)", "FCC sub group (Diamond)", "FCC sub group (Zincblende)", 3, 5),
        new assessment1 ("What is the crystal name for the atomic structure shown?", "FCC (Nickel)", "FCC salt", "Simple cubic (polonium)", "FCC sub group (Diamond)", 3, 4),
        new assessment1 ("What is the crystal name for the atomic structure shown?", "FCC salt", "Simple cubic (polonium)", "FCC (Nickel)", "FCC sub group (Diamond)", 0, 3),
        new assessment1 ("What is the crystal name for the atomic structure shown?", "FCC sub group (Zincblende)", "Simple cubic (polonium)", "FCC sub group (Diamond)", "FCC (Nickel)", 0, 5),
        new assessment1 ("What is the crystal name for the atomic structure shown?", "FCC salt", "FCC sub group (Diamond)", "Simple cubic (polonium)", "FCC (Nickel)", 1, 4),
        new assessment1 ("What is the crystal name for the atomic structure shown?", "FCC sub group (Diamond)", "Simple cubic (polonium)", "FCC salt", "BCC (Iron)", 3, 1),
        new assessment1 ("What is the crystal name for the atomic structure shown?", "BCC (Iron)", "FCC sub group (Diamond)", "FCC (Nickel)", "Simple cubic (polonium)", 3, 0),
        new assessment1 ("What is the crystal name for the atomic structure shown?", "FCC (Nickel)", "FCC sub group (Zincblende)", "FCC sub group (Diamond)", "BCC (IRon)", 1, 5),
        new assessment1 ("What is the crystal name for the atomic structure shown?", "FCC (Nickel)", "BCC (IRon)", "FCC sub group (Diamond)", "FCC sub group (Zincblende)", 1, 2),
        new assessment1 ("What is the crystal name for the atomic structure shown?", "BCC (IRon)", "FCC (Nickel)", "FCC sub group (Diamond)", "FCC salt", 3, 3),
        new assessment1 ("What is the crystal name for the atomic structure shown?", "FCC (Nickel)", "BCC (IRon)", "BCC (CsCl)", "FCC salt", 2, 6),
        new assessment1 ("What is the crystal name for the atomic structure shown?", "FCC sub group (Diamond)", "BCC (CsCl)", "BCC (IRon)", "BCC (salt)", 1, 6)
    };
public static assessment2[] q2 = new assessment2[] 
    {
        new assessment2 ("Which of the atomic structure is for bcc (Iron)?", 0, 1, 2, 3, 1),
        new assessment2 ("Which of the atomic structure is for fcc (Salt)?", 0, 1, 2, 3, 3),
        new assessment2 ("Which of the atomic structure is for fcc sub group (Diamond)?", 1, 0, 4, 5, 2),
        new assessment2 ("Which of the atomic structure is for fcc sub group (Zincblende)?", 1, 3, 0, 5, 3),
        new assessment2 ("Which of the atomic structure is for simple cube (Polonium)?", 0, 1, 2, 3, 0),
        new assessment2 ("Which of the atomic structure is for bcc (CsCl)", 4, 2, 6, 3, 2),
        new assessment2 ("Which of the atomic structure is for fcc (Nickel)?", 4, 2, 0, 3, 1),
        new assessment2 ("Which of the atomic structure is for bcc (iron)?", 1, 4, 6, 2, 0),
        new assessment2 ("Which of the atomic structure is for fcc (salt)?", 2, 3, 0, 5, 1),
        new assessment2 ("Which of the atomic structure is for fcc sub group (Diamond)?", 4, 0, 5, 6, 0),
        new assessment2 ("Which of the atomic structure is for fcc sub group (Zincblende)?", 4, 5, 0, 2, 1),
        new assessment2 ("Which of the atomic structure is for simple cube (Polonium)?", 2, 1, 0, 4, 2),
        new assessment2 ("Which of the atomic structure is for bcc (CsCl)?", 5, 6, 4, 2, 1),
        new assessment2 ("Which of the atomic structure is for fcc (Nickel)?", 0, 6, 3, 2, 3)
    };
}
