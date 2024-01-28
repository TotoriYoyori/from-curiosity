using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeCheck : MonoBehaviour
{
    public TextMesh firstElement;
    public TextMesh firstSubscript;
    public TextMesh secondElement;
    public TextMesh secondSubscript;
    public GameObject attack;
    public string molecule;

    public battleManager manager;

    // Start is called before the first frame update
    void Start()
    {
        attack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        molecule = firstElement.text + firstSubscript.text + secondElement.text + secondSubscript.text;
        manager.setMolecule(molecule);

        if (molecule == "CH4" || molecule == "C2H4" || molecule == "O2" || molecule == "H2O" || molecule == "SO3" || molecule == "C2H6" || molecule == "C3H8" || molecule == "ClO3" || molecule == "NO3" || molecule == "CO3" || molecule == "NaCl" || molecule == "HCl")
        {
            attack.SetActive(true);
        }
        else
        {
            attack.SetActive(false);
        }
    }
}
