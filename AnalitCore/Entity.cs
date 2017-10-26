namespace AnalitCore
{
	public class Entity
	{
		public int id;
		public string title;
		public long price;

		public Entity(int id,string title, long price)
		{
			this.id = id;
			this.title = title;
			this.price = price;
		}
	}
}