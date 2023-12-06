namespace shared.Model;

public class DagligSkæv : Ordination {
    public List<Dosis> doser { get; set; } = new List<Dosis>();

    public DagligSkæv(DateTime startDen, DateTime slutDen, Laegemiddel laegemiddel) : base(laegemiddel, startDen, slutDen) {
	}

    public DagligSkæv(DateTime startDen, DateTime slutDen, Laegemiddel laegemiddel, Dosis[] doser) : base(laegemiddel, startDen, slutDen) {
        this.doser = doser.ToList();
    }    

    public DagligSkæv() : base(null!, new DateTime(), new DateTime()) {
    }

	public void opretDosis(DateTime tid, double antal) 
	{
		if (antal <= 0)
		{
			throw new ArgumentOutOfRangeException("Kan ikke oprette negativ antal dosis");
		}
		else if (tid < startDen)
		{
			throw new ArgumentOutOfRangeException("Kan ikke oprette dosis før ordinationsperioden");
		}
		else if (tid > slutDen)
		{
			throw new ArgumentOutOfRangeException("Kan ikke oprette dosis efter ordinationsperioden");
		}
		else
		{
			doser.Add(new Dosis(tid, antal));
		}
    }

	public override double samletDosis() {
		return base.antalDage() * doegnDosis();
	}

	public override double doegnDosis() 
	{
        return doser.Sum(d => d.antal) / antalDage();
	}

	public override String getType() {
		return "DagligSkæv";
	}
}
