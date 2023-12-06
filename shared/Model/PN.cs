namespace shared.Model;

public class PN : Ordination {
	public double antalEnheder { get; set; }
    public List<Dato> dates { get; set; } = new List<Dato>();

    public PN (DateTime startDen, DateTime slutDen, double antalEnheder, Laegemiddel laegemiddel) : base(laegemiddel, startDen, slutDen) {
		this.antalEnheder = antalEnheder;
	}

    public PN() : base(null!, new DateTime(), new DateTime()) {
    }

    /// <summary>
    /// Registrerer at der er givet en dosis på dagen givesDen
    /// Returnerer true hvis givesDen er inden for ordinationens gyldighedsperiode og datoen huskes
    /// Returner false ellers og datoen givesDen ignoreres
    /// </summary>
    public bool givDosis(Dato givesDen) 
    {
        if (givesDen.dato <= slutDen && givesDen.dato >= startDen)
        {
            dates.Add(givesDen);
            return true;
        }
        return false;
    }

    public override double doegnDosis() 
    {
        if (dates.Count > 0)
        {
            Dato mindag = dates.First();
            Dato maxdag = dates.First();

            foreach (Dato dag in dates)
            {
                if (dag.dato < mindag.dato)
                {
                    mindag = dag;
                }
                else if (dag.dato > maxdag.dato)
                {
                    maxdag = dag;
                }
            }

            return (samletDosis()) / ((maxdag.dato - mindag.dato).TotalDays + 1);
        }
        return 0;
    }


    public override double samletDosis() {
        return getAntalGangeGivet() * antalEnheder;
    }

    public int getAntalGangeGivet() {
        return dates.Count();
    }

	public override String getType() {
		return "PN";
	}
}
