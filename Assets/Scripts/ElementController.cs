using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using dllsubscript;

public class ElementController : MonoBehaviour 
{
	public Text EquationText;
	public GameObject equationHolder;
	public ChemicalEquation currentEquation;
	List<Element> Elements = new List<Element>();
	List<ChemicalEquation> Equations = new List<ChemicalEquation>();
	Subscript ss = new Subscript();
	public Transform dragablePrefab;
	public Transform testTransform;
	public List<GameObject> dropZoneList = new List<GameObject>();
	public GameObject startingPoint;

	List<string> numerValueList = new List<string>();
	List<string> denomValueList = new List<string>();
	List<string> numerUnitsList = new List<string>();
	List<string> denomUnitsList = new List<string>();


	public class Element
	{
		public string Name;
		public string Symbol;
		public int AtomicNumber;
		public decimal AtomicWeight;
		public int GroupNumber;
		public int Period;
		public string Category;

		public Element(int atomicNumber, string symbol, string name, decimal atomicWeight)
		{
			Name = name;
			Symbol = symbol;
			AtomicNumber = atomicNumber;
			AtomicWeight = atomicWeight;
		}
	}

	public class Chemical
	{
		public int chemicalMultiplier;
		public Element chemicalElement;

		public Chemical(Element ce, int cm)
		{
			chemicalElement = ce;
			chemicalMultiplier = cm;
		}
	}

	public class ChemicalFormula
	{
		public int formulaMultiplier;
		public List<Chemical> Formula;
		public string displayName;
		public float formulaWeight;
		public float numberOfMoles;
		public float numberOfAtoms;
		public float litersOfGas;
		public float litersOfSolution;
		public float molarity;
		public float molarMass;

		public ChemicalFormula(int fm)
		{
			formulaMultiplier = fm;
			Formula = new List<Chemical>();
		}

		public ChemicalFormula()
		{
			Formula = new List<Chemical>();
		}
	}

	public class ChemicalEquation
	{
		public List<ChemicalFormula> Formulas;
		public List<string> formulaOperators;
		public bool balanced;

		public ChemicalEquation()
		{
			Formulas = new List<ChemicalFormula>();
			formulaOperators = new List<string>();
			balanced = false;
		}
	}

	void Start()
	{
		Elements.Add(new Element(1,     "H",    "Hydrogen",     1.007825M ));
		Elements.Add(new Element(2,     "He",   "Helium",       4.00260M  ));
		Elements.Add(new Element(3,     "Li",   "Lithium",      6.941M    ));
		Elements.Add(new Element(4,     "Be",   "Beryllium",    9.01218M  ));
		Elements.Add(new Element(5,     "B",    "Boron",        10.81M    ));
		Elements.Add(new Element(6,     "C",    "Carbon",       12.011M   ));
		Elements.Add(new Element(7,     "N",    "Nitrogen",     14.0067M  ));
		Elements.Add(new Element(8,     "O",    "Oxygen",       15.999M   ));
		Elements.Add(new Element(9,     "F",    "Fluorine",     18.99840M ));
		Elements.Add(new Element(10,    "Ne",   "Neon",         20.179M   ));
		Elements.Add(new Element(11,    "Na",   "Sodium",       22.98977M ));
		Elements.Add(new Element(12,    "Mg",   "Magnesium",    24.305M   ));
		Elements.Add(new Element(13,    "Al",   "Aluminum",     26.98154M ));
		Elements.Add(new Element(14,    "Si",   "Silicon",      28.0855M  ));
		Elements.Add(new Element(15,    "P",    "Phosphorus",   0.0M      ));
		Elements.Add(new Element(16,    "S",    "Sulphur",      32.06M    ));
		Elements.Add(new Element(17,    "Cl",   "Chlorine",     35.453M   ));
		Elements.Add(new Element(18,    "Ar",   "Argon",        39.948M   ));
		Elements.Add(new Element(19,    "K",    "Potassium",    39.0983M  ));
		Elements.Add(new Element(20,    "Ca",   "Calcium",      40.08M    ));
		Elements.Add(new Element(21,    "Sc",   "Scandium",     44.9559M  ));
		Elements.Add(new Element(22,    "Ti",   "Titanium",     47.90M    ));
		Elements.Add(new Element(23,    "V",    "Vanadium",     50.9414M  ));
		Elements.Add(new Element(24,    "Cr",   "Chromium",     51.996M   ));
		Elements.Add(new Element(25,    "Mn",   "Manganese",    54.9380M  ));
		Elements.Add(new Element(26,    "Fe",   "Iron",         55.85M    ));
		Elements.Add(new Element(27,    "Co",   "Cobalt",       58.9332M  ));
		Elements.Add(new Element(28,    "Ni",   "Nickel",       58.71M    ));
		Elements.Add(new Element(29,    "Cu",   "Copper",       63.546M   ));
		Elements.Add(new Element(30,    "Zn",   "Zinc",         65.37M    ));
		Elements.Add(new Element(31,    "Ga",   "Gallium",      69.72M    ));
		Elements.Add(new Element(32,    "Ge",   "Germanium",    72.59M    ));
		Elements.Add(new Element(33,    "As",   "Arsenic",      74.9216M  ));
		Elements.Add(new Element(34,    "Se",   "Selenium",     78.96M    ));
		Elements.Add(new Element(35,    "Br",   "Bromine",      79.904M   ));
		Elements.Add(new Element(36,    "Kr",   "Krypton",      83.80M    ));
		Elements.Add(new Element(37,    "Rb",   "Rubidium",     85.4678M  ));
		Elements.Add(new Element(38,    "Sr",   "Strontium",    87.62M    ));
		Elements.Add(new Element(39,    "Y",    "Yttrium",      88.9059M  ));
		Elements.Add(new Element(40,    "Zr",   "Zirconium",    91.22M    ));
		Elements.Add(new Element(41,    "Nb",   "Niobium",      92.91M    ));
		Elements.Add(new Element(42,    "Mo",   "Molybdenum",   95.94M    ));
		Elements.Add(new Element(43,    "Tc",   "Technetium",   99.0M     ));
		Elements.Add(new Element(44,    "Ru",   "Ruthenium",    101.1M    ));
		Elements.Add(new Element(45,    "Rh",   "Rhodium",      102.91M   ));
		Elements.Add(new Element(46,    "Pd",   "Palladium",    106.42M   ));
		Elements.Add(new Element(47,    "Ag",   "Silver",       107.87M   ));
		Elements.Add(new Element(48,    "Cd",   "Cadmium",      112.4M    ));
		Elements.Add(new Element(49,    "In",   "Indium",       114.82M   ));
		Elements.Add(new Element(50,    "Sn",   "Tin",          118.69M   ));
		Elements.Add(new Element(51,    "Sb",   "Antimony",     121.75M   ));
		Elements.Add(new Element(52,    "Te",   "Tellurium",    127.6M    ));
		Elements.Add(new Element(53,    "I",    "Iodine",       126.9045M ));
		Elements.Add(new Element(54,    "Xe",   "Xenon",        131.29M   ));
		Elements.Add(new Element(55,    "Cs",   "Cesium",       132.9054M ));
		Elements.Add(new Element(56,    "Ba",   "Barium",       137.33M   ));
		Elements.Add(new Element(57,    "La",   "Lanthanum",    138.91M   ));
		Elements.Add(new Element(58,    "Ce",   "Cerium",       140.12M   ));
		Elements.Add(new Element(59,    "Pr",   "Praseodymium", 140.91M   ));
		Elements.Add(new Element(60,    "Nd",   "Neodymium",    0.0M      ));
		Elements.Add(new Element(61,    "Pm",   "Promethium",   147.0M    ));
		Elements.Add(new Element(62,    "Sm",   "Samarium",     150.35M   ));
		Elements.Add(new Element(63,    "Eu",   "Europium",     167.26M   ));
		Elements.Add(new Element(64,    "Gd",   "Gadolinium",   157.25M   ));
		Elements.Add(new Element(65,    "Tb",   "Terbium",      158.925M  ));
		Elements.Add(new Element(66,    "Dy",   "Dysprosium",   162.50M   ));
		Elements.Add(new Element(67,    "Ho",   "Holmium",      164.9M    ));
		Elements.Add(new Element(68,    "Er",   "Erbium",       167.26M   ));
		Elements.Add(new Element(69,    "Tm",   "Thulium",      168.93M   ));
		Elements.Add(new Element(70,    "Yb",   "Ytterbium",    173.04M   ));
		Elements.Add(new Element(71,    "Lu",   "Lutetium",     174.97M   ));
		Elements.Add(new Element(72,    "Hf",   "Hafnium",      178.49M   ));
		Elements.Add(new Element(73,    "Ta",   "Tantalum",     180.95M   ));
		Elements.Add(new Element(74,    "W",    "Tungsten",     183.85M   ));
		Elements.Add(new Element(75,    "Re",   "Rhenium",      186.23M   ));
		Elements.Add(new Element(76,    "Os",   "Osmium",       190.2M    ));
		Elements.Add(new Element(77,    "Ir",   "Iridium",      192.2M    ));
		Elements.Add(new Element(78,    "Pt",   "Platinum",     195.09M   ));
		Elements.Add(new Element(79,    "Au",   "Gold",         196.9655M ));
		Elements.Add(new Element(80,    "Hg",   "Mercury",      200.59M   ));
		Elements.Add(new Element(81,    "Tl",   "Thallium",     204.383M  ));
		Elements.Add(new Element(82,    "Pb",   "Lead",         207.2M    ));
		Elements.Add(new Element(83,    "Bi",   "Bismuth",      208.9804M ));
		Elements.Add(new Element(84,    "Po",   "Polonium",     210.0M    ));
		Elements.Add(new Element(85,    "At",   "Astatine",     210.0M    ));
		Elements.Add(new Element(86,    "Rn",   "Radon",        222.0M    ));
		Elements.Add(new Element(87,    "Fr",   "Francium",     233.0M    ));
		Elements.Add(new Element(88,    "Ra",   "Radium",       226.0254M ));
		Elements.Add(new Element(89,    "Ac",   "Actinium",     227.0M    ));
		Elements.Add(new Element(90,    "Th",   "Thorium",      232.04M   ));
		Elements.Add(new Element(91,    "Pa",   "Protactinium", 231.0359M ));
		Elements.Add(new Element(92,    "U",    "Uranium",      238.03M   ));
		Elements.Add(new Element(93,    "Np",   "Neptunium",    237.0M    ));
		Elements.Add(new Element(94,    "Pu",   "Plutonium",    244.0M    ));
		Elements.Add(new Element(95,    "Am",   "Americium",    243.0M    ));
		Elements.Add(new Element(96,    "Cm",   "Curium",       247.0M    ));
		Elements.Add(new Element(97,    "Bk",   "Berkelium",    247.0M    ));
		Elements.Add(new Element(98,    "Cf",   "Californium",  251.0M    ));
		Elements.Add(new Element(99,    "Es",   "Einsteinium",  254.0M    ));
		Elements.Add(new Element(100,   "Fm",   "Fermium",      257.0M    ));
		Elements.Add(new Element(101,   "Md",   "Mendelevium",  258.0M    ));
		Elements.Add(new Element(102,   "No",   "Nobelium",     259.0M    ));
		Elements.Add(new Element(103,   "Lr",   "Lawrencium",   262.0M    ));
		Elements.Add(new Element(104,   "Rf",   "Rutherfordium",260.9M    ));
		Elements.Add(new Element(105,   "Db",   "Dubnium",      261.9M    ));
		Elements.Add(new Element(106,   "Sg",   "Seaborgium",   262.94M   ));
		Elements.Add(new Element(107,   "Bh",   "Bohrium",      262.0M    ));
		Elements.Add(new Element(108,   "Hs",   "Hassium",      264.8M    ));
		Elements.Add(new Element(109,   "Mt",   "Meitnerium",   265.9M    ));
		Elements.Add(new Element(110,   "Ds",   "Darmstadtium", 261.9M    ));
		Elements.Add(new Element(112,   "Uub",  "Ununbium",     276.8M    ));
		Elements.Add(new Element(114,   "Uuq",  "Ununquadium",  289.0M    ));
		Elements.Add(new Element(116,   "Uuh",  "Ununhexium",   0.0M      ));

		//Build list of Chemical Equations
		Equations.Add(new ChemicalEquation());
		Equations[Equations.Count-1].Formulas.Add(new ChemicalFormula(2));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].Formula.Add(new Chemical(Elements[12], 1));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].molarMass = getMolarMass(Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1]);
		Equations[Equations.Count-1].formulaOperators.Add(" + ");
		Equations[Equations.Count-1].Formulas.Add(new ChemicalFormula(3));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].Formula.Add(new Chemical(Elements[28], 1));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].Formula.Add(new Chemical(Elements[16], 2));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].molarMass = getMolarMass(Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1]);
		Equations[Equations.Count-1].formulaOperators.Add(" --> ");
		Equations[Equations.Count-1].Formulas.Add(new ChemicalFormula(3));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].Formula.Add(new Chemical(Elements[28], 1));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].molarMass = getMolarMass(Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1]);
		Equations[Equations.Count-1].formulaOperators.Add(" + ");
		Equations[Equations.Count-1].Formulas.Add(new ChemicalFormula(2));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].Formula.Add(new Chemical(Elements[12], 1));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].Formula.Add(new Chemical(Elements[16], 3));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].molarMass = getMolarMass(Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1]);
		Equations[Equations.Count - 1].balanced = true;

		Equations.Add(new ChemicalEquation());
		Equations[Equations.Count-1].Formulas.Add(new ChemicalFormula(16));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].Formula.Add(new Chemical(Elements[18], 1));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].molarMass = getMolarMass(Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1]);
		Equations[Equations.Count-1].formulaOperators.Add(" + ");
		Equations[Equations.Count-1].Formulas.Add(new ChemicalFormula(1));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].Formula.Add(new Chemical(Elements[15], 8));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].molarMass = getMolarMass(Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1]);
		Equations[Equations.Count-1].formulaOperators.Add(" --> ");
		Equations[Equations.Count-1].Formulas.Add(new ChemicalFormula(8));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].Formula.Add(new Chemical(Elements[18], 2));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].Formula.Add(new Chemical(Elements[15], 1));
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].molarMass = getMolarMass(Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1]);
		Equations[Equations.Count-1].balanced = true;

		Equations.Add(new ChemicalEquation());
		Equations[Equations.Count-1].Formulas.Add(new ChemicalFormula(2)); //Coefficient 2
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].Formula.Add(new Chemical(Elements[0], 2)); //2 Hydrogen
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count -	1].Formula.Add(new Chemical(Elements[7], 2)); // 2 Oxygen
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].molarMass = getMolarMass(Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1]);
		Equations[Equations.Count-1].formulaOperators.Add(" --> "); // Reaction
		Equations[Equations.Count-1].Formulas.Add(new ChemicalFormula(2)); //Coefficient 2
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].Formula.Add(new Chemical(Elements[0], 2)); // 2 Hydrogen
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].Formula.Add(new Chemical(Elements[7], 1)); //One Oxygen
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].molarMass = getMolarMass(Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1]);
		Equations[Equations.Count-1].formulaOperators.Add(" + "); //Add
		Equations[Equations.Count-1].Formulas.Add(new ChemicalFormula(1));//Coefficient 1
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].Formula.Add(new Chemical(Elements[7], 2));//2 Oxygen
		Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1].molarMass = getMolarMass(Equations[Equations.Count-1].Formulas[Equations[Equations.Count-1].Formulas.Count - 1]);
		Equations[Equations.Count-1].balanced = true;


		currentEquation = Equations[Equations.Count-1];
		displayChemicalEquation();
		//setUpDragGame(8.25f, "g " + currentEquation.Formulas[0].displayName, currentEquation.Formulas[0], currentEquation.Formulas[currentEquation.Formulas.Count-1], "Grams", "Grams");
		//equationHolder.GetComponent<EquationController>().addFormula(Equations[Equations.Count-1]);
	}

	public void solveWithGrams(int index, float weight)
	{
		//find the moles for a chemical formula given its index and weight
		Debug.Log("Index:"+index+"  Value:"+ weight);
		currentEquation.Formulas[index].formulaWeight = weight;
		currentEquation.Formulas[index].numberOfMoles = gramsToMoles(currentEquation.Formulas[index], currentEquation.Formulas[index].formulaWeight);
		Debug.Log("There are " + currentEquation.Formulas[index].numberOfMoles + " Moles in " + currentEquation.Formulas[index].formulaWeight + "g of " + currentEquation.Formulas[index].displayName);
		solveWithMoles(index, currentEquation.Formulas[index].numberOfMoles);
	}

	public void solveWithMoles(int index, float moles)
	{
		currentEquation.Formulas[index].numberOfMoles = moles;
		//find the moles of the other unsolved chemical formulas using the data gathered above
		for (int i = 0; i < currentEquation.Formulas.Count; i++)
		{
			currentEquation.Formulas[i].numberOfMoles = (currentEquation.Formulas[index].numberOfMoles * currentEquation.Formulas[i].formulaMultiplier) / currentEquation.Formulas[index].formulaMultiplier;
			currentEquation.Formulas[i].formulaWeight = molesToGrams(currentEquation.Formulas[i], currentEquation.Formulas[i].numberOfMoles);
			Debug.Log("There are " + currentEquation.Formulas[i].numberOfMoles + " Moles in " + currentEquation.Formulas[i].displayName);
			currentEquation.Formulas[i].numberOfAtoms = molesToAtoms(currentEquation.Formulas[i].numberOfMoles);
			currentEquation.Formulas[i].litersOfGas = molesToLitersOfGas(currentEquation.Formulas[i], currentEquation.Formulas[i].numberOfMoles);
			Transform hold = GameObject.Find("ChemicalEquation").transform.GetChild(i);
			hold.GetChild(1).GetComponent<InputField>().text = currentEquation.Formulas[i].numberOfMoles.ToString();
			hold.GetChild(0).GetComponent<InputField>().text = currentEquation.Formulas[i].formulaWeight.ToString();
			hold.GetChild(2).GetComponent<InputField>().text = currentEquation.Formulas[i].numberOfAtoms.ToString();
			hold.GetChild(3).GetComponent<InputField>().text = currentEquation.Formulas[i].litersOfGas.ToString();
		}
	}

	public void solveWithLitersOfGas(int index, float litersOfGas)
	{
		currentEquation.Formulas[index].numberOfMoles = (litersOfGas / 22.4f);
		solveWithMoles(index, currentEquation.Formulas[index].numberOfMoles);
	}

	public void solveWithAtoms(int index, float numberOfAtoms)
	{
		currentEquation.Formulas[index].numberOfMoles = (numberOfAtoms / (6.02f * Mathf.Pow(10.0f, 23.0f)));
		solveWithMoles(index, currentEquation.Formulas[index].numberOfMoles);
	}

	void displayChemicalEquation()
	{
		if(GetComponent<CheckValueScript>())
		{
			GetComponent<CheckValueScript>().ResetArrays();
		}

		ChemicalEquation equ = currentEquation;
		string hold = "";
		for (int i = 0; i < equ.Formulas.Count; i++)
		{
			hold += equ.Formulas[i].formulaMultiplier + equ.Formulas[i].displayName;

			if(GetComponent<CheckValueScript>())
			{
				GetComponent<CheckValueScript>().numbers.Add(equ.Formulas[i].formulaMultiplier);
				GetComponent<CheckValueScript>().elements.Add(equ.Formulas[i]);
			}

			if (i < equ.formulaOperators.Count)
			{
				hold += equ.formulaOperators[i];

				if(GetComponent<CheckValueScript>())
				{
					GetComponent<CheckValueScript>().operators.Add(equ.formulaOperators[i]);
				}
			}
		}
		EquationText.text = hold;
		//Debug.Log();
		if(GetComponent<CheckValueScript>())
		{
			GetComponent<CheckValueScript>().UpdateValues();
		}
	}

	float gramsToMoles(ChemicalFormula form, float weight)
	{
		return (weight / form.molarMass);
	}

	float molesToGrams(ChemicalFormula form, float moles)
	{
		if (form.molarMass != 0)
		{
			return (moles * form.molarMass);
		}
		else
		{
			return (moles * getMolarMass(form));
		}
	}

	float molesToLitersOfGas(ChemicalFormula form, float moles)
	{
		return (form.numberOfMoles * 22.4f);
	}

	float molesToLitersOfSolution(ChemicalEquation form, float moles)
	{
		return (0.0f);
	}

	float molesToAtoms(float moles)
	{
		return (moles * 6.02f * Mathf.Pow(10.0f, 23.0f));
	}

	float molesToMoles(ChemicalFormula formA, ChemicalFormula formB)
	{
		return (formA.formulaMultiplier / formB.formulaMultiplier);
	}

	float getMolarMass(ChemicalFormula form)
	{
		decimal molarMass = 0;
		string sub;
		string chemicalFormula = "";
		for (int i = 0; i < form.Formula.Count; i++)
		{
			molarMass += (form.Formula[i].chemicalElement.AtomicWeight * form.Formula[i].chemicalMultiplier);
			if (form.Formula[i].chemicalMultiplier > 1)
			{
				sub = ss.ToSubscript(form.Formula[i].chemicalMultiplier);
			}
			else
			{
				sub = "";
			}
			chemicalFormula += form.Formula[i].chemicalElement.Symbol + sub;
		}
		form.displayName = chemicalFormula;
		Debug.Log("The molar mass of " + chemicalFormula + " is " + molarMass);
		return (float) molarMass;
	}

	void balanceEquation(ChemicalEquation equ)
	{
		//start with most complex chemical formula to the least
		//work from first element of the most complex formula to the last
		//balance as you go
		//avoid breaking balance

	}

	public void setUpDragGame(float startingValue, string startingUnits, ChemicalFormula formulaA, ChemicalFormula formulaB, string convertFrom, string convertTo)
	{
		Debug.Log("startingValue:" + startingValue + "   StartingUnits:" + startingUnits);
		switch (startingUnits)
		{
			case "Grams":
				{
					startingPoint.GetComponent<DragItemData>().units = "g " + formulaA.displayName;
					break;
				}
			case "Liters":
				{
					startingPoint.GetComponent<DragItemData>().units = "L " + formulaA.displayName;
					break;
				}
			case "Particles":
				{
					startingPoint.GetComponent<DragItemData>().units = "Part. " + formulaA.displayName;
					break;
				}
			case "Moles":
				{
					startingPoint.GetComponent<DragItemData>().units = "mol " + formulaA.displayName;
					break;
				}
		}
		startingPoint.GetComponent<DragItemData>().value = startingValue.ToString();
		startingPoint.GetComponent<Text>().text = startingPoint.GetComponent<DragItemData>().value + startingPoint.GetComponent<DragItemData>().units;
		Transform part1 = Instantiate(dragablePrefab);
		part1.transform.SetParent(testTransform);
		part1.transform.localScale = new Vector3(1, 1, 1);
		part1.GetComponent<DragItemData>().forumlaName = formulaA.displayName;
		switch (convertFrom)
		{
			case "Grams":
				{
					part1.GetComponent<DragItemData>().units = "g " + formulaA.displayName;
					part1.GetComponent<DragItemData>().value = getMolarMass(formulaA).ToString();
					Debug.Log("Given " + startingValue + startingUnits + " of " + formulaA.displayName + ", calculate the "); 
					part1.transform.GetComponentInChildren<Text>().text = getMolarMass(formulaA).ToString("0.00") + " g " + formulaA.displayName;
					break;
				}
			case "Liters":
				{
					part1.GetComponent<DragItemData>().units = "L " + formulaA.displayName;
					part1.GetComponent<DragItemData>().value = "22.4";
					part1.transform.GetComponentInChildren<Text>().text = "22.4" + " L " + formulaA.displayName;
					break;
				}
			case "Particles":
				{
					part1.GetComponent<DragItemData>().units = "Part. " + formulaA.displayName;
					part1.GetComponent<DragItemData>().value = "6.0223*10^23";
					part1.transform.GetComponentInChildren<Text>().text = "6.0223*10^23" + " Part. " + formulaA.displayName;
					break;
				}
			case "Moles":
				{
					//Destroy(part1.gameObject);
					break;
				}
		}

		//Static Reactants
		Transform part2 = Instantiate(dragablePrefab);
		part2.transform.SetParent(testTransform);
		part2.transform.localScale = new Vector3(1, 1, 1);
		part2.GetComponent<DragItemData>().units = "mol " + formulaA.displayName;
		part2.GetComponent<DragItemData>().value = "1";
		part2.GetComponent<DragItemData>().forumlaName = formulaA.displayName;
		part2.transform.GetComponentInChildren<Text>().text = "1" + " mol " + formulaA.displayName ;
		Transform part3 = Instantiate(dragablePrefab);
		part3.transform.SetParent(testTransform);
		part3.transform.localScale = new Vector3(1, 1, 1);
		part3.GetComponent<DragItemData>().units = "mol " + formulaA.displayName;
		part3.GetComponent<DragItemData>().value = formulaA.formulaMultiplier.ToString();
		part3.GetComponent<DragItemData>().forumlaName = formulaA.displayName;
		part3.transform.GetComponentInChildren<Text>().text = formulaA.formulaMultiplier + " mol " + formulaA.displayName;

		//Static Products
		Transform part4 = Instantiate(dragablePrefab);
		part4.transform.SetParent(testTransform);
		part4.transform.localScale = new Vector3(1, 1, 1);
		part4.GetComponent<DragItemData>().units = "mol " + formulaB.displayName;
		part4.GetComponent<DragItemData>().value = formulaB.formulaMultiplier.ToString();
		part4.GetComponent<DragItemData>().forumlaName = formulaB.displayName;
		part4.transform.GetComponentInChildren<Text>().text = formulaB.formulaMultiplier + " mol " + formulaB.displayName ;
		Transform part6 = Instantiate(dragablePrefab);
		part6.transform.SetParent(testTransform);
		part6.transform.localScale = new Vector3(1, 1, 1);
		part6.GetComponent<DragItemData>().units = "mol " + formulaB.displayName;
		part6.GetComponent<DragItemData>().value = "1";
		part6.GetComponent<DragItemData>().forumlaName = formulaB.displayName;
		part6.transform.GetComponentInChildren<Text>().text = "1" + " mol " + formulaB.displayName;


		Transform part5 = Instantiate(dragablePrefab);
		part5.transform.SetParent(testTransform);
		part5.transform.localScale = new Vector3(1, 1, 1);
		part5.GetComponent<DragItemData>().forumlaName = formulaB.displayName;
		switch (convertTo)
		{
			case "Grams":
				{
					part5.GetComponent<DragItemData>().units = "g " + formulaB.displayName;
					part5.GetComponent<DragItemData>().value = getMolarMass(formulaB).ToString();
					part5.transform.GetComponentInChildren<Text>().text = getMolarMass(formulaB).ToString("0.00") + " g " + formulaB.displayName;
					break;
				}
			case "Liters":
				{
					part5.GetComponent<DragItemData>().units = "L " + formulaB.displayName;
					part5.GetComponent<DragItemData>().value = "22.4";
					part5.transform.GetComponentInChildren<Text>().text = "22.4" + " L " + formulaB.displayName;
					break;
				}
			case "Particles":
				{
					part5.GetComponent<DragItemData>().units = "Part. " + formulaB.displayName;
					part5.GetComponent<DragItemData>().value = "6.0223*10^23";
					part5.transform.GetComponentInChildren<Text>().text = "6.0223*10^23" + " Part. " + formulaB.displayName;
					break;
				}
			case "Moles":
				{
					//Destroy(part5.gameObject);
					break;
				}
		}
		calcTableResults();
	}

	public void calcTableResults()
	{
		float calculatedNumerator = 1.0f;
		float calculatedDenominator = 1.0f;
		string numerator = "";
		string denominator = "";
		numerUnitsList.Clear();
		numerValueList.Clear();
		denomUnitsList.Clear();
		denomValueList.Clear();

		numerUnitsList.Add(startingPoint.GetComponent<DragItemData>().units);
		numerValueList.Add(startingPoint.GetComponent<DragItemData>().value);
		for (int k = 0; k < dropZoneList.Count; k++)
		{
			if (dropZoneList[k].transform.childCount > 0)
			{
				if(dropZoneList[k].name == "StartingPoint" || dropZoneList[k].name == "DropZone1" || dropZoneList[k].name == "DropZone3" || dropZoneList[k].name == "DropZone5")
				{
					numerUnitsList.Add(dropZoneList[k].GetComponentInChildren<DragItemData>().units);
					numerValueList.Add(dropZoneList[k].GetComponentInChildren<DragItemData>().value);
				}
				else if(dropZoneList[k].name == "DropZone2" || dropZoneList[k].name == "DropZone4" || dropZoneList[k].name == "DropZone6")
				{
					denomUnitsList.Add(dropZoneList[k].GetComponentInChildren<DragItemData>().units);
					denomValueList.Add(dropZoneList[k].GetComponentInChildren<DragItemData>().value);
				}
			}
		}
			
		for (int l = 0; l < numerUnitsList.Count; l++)
		{
			for (int m = 0; m < denomUnitsList.Count; m++)
			{
				if (numerUnitsList[l] == denomUnitsList[m])
				{
					numerUnitsList.RemoveAt(l);
					denomUnitsList.RemoveAt(m);
					l--;
					break;
				}
			}
		}
		//used for displaying non-tabulated results (IE: 8*5*13*5)
		/*
		for (int i = 0; i < numerValueList.Count; i++)
		{
			numerator += numerValueList[i];
			if (i < numerValueList.Count - 1)
			{
				numerator += " * ";
			}
		}
		*/

		for (int p = 0; p < numerValueList.Count; p++)
		{
			calculatedNumerator *= float.Parse(numerValueList[p]);
			//Debug.Log("CalculatedNumber:" + calculatedNumerator);
		}
			
		for (int q = 0; q < denomValueList.Count; q++)
		{
			calculatedDenominator *= float.Parse(denomValueList[q]);
		}

		//used for displaying non-tabulate results (IE: 5*8*9*7)
		/*
		for (int j = 0; j < denomValueList.Count; j++)
		{
			if (j == 0)
			{
				denominator += " / ";
			}
			denominator += denomValueList[j];
			if (j < denomValueList.Count - 1)
			{
				denominator += " * ";
			}
		}
		*/

		for (int n = 0; n < numerUnitsList.Count; n++)
		{
			numerator += " " + numerUnitsList[n];
		}
		for (int o = 0; o < denomUnitsList.Count; o++)
		{
			if (o == 0)
			{
				denominator += " / ";
			}
			denominator += " " + denomUnitsList[o];
		}
			

		GameObject.Find("Solution").GetComponent<Text>().text = (calculatedNumerator/calculatedDenominator).ToString("F") + numerator + denominator ;
	}
}
