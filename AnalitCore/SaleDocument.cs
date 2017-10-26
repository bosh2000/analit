using System;
using System.Collections.Generic;
using MysqlCore;

namespace AnalitCore
{
	public class SaleDocument
	{
		// Дата документа.
		public DateTime dateDocument;
		// Номер документа.
		public long numberDocument;

		struct LineDocument
		{
			// Товар.
			public Entity entity;
			// Цена.
			public long price;
			// Количество 
			public long countEntity;
			// Сумма.
			public long amountPrice;
		}

		private List<LineDocument> listsDocument=new List<LineDocument>();

		public void AddLineToDocument(Entity entity,int countEntity)
		{
			LineDocument line = new LineDocument
			{
				entity = entity,
				price = entity.price,
				countEntity = countEntity,
				amountPrice = entity.price * countEntity
			};
			listsDocument.Add(line);
		}
		
		public int OpenDocument()
		{
			dateDocument=DateTime.Now;
			numberDocument = GetLastNumberDocument() + 1;
			return 0;
		}

		public void CloseDocument()
		{
		}

		public long GetLastNumberDocument()
		{
			
			MySqlData myCon=new MySqlData();
			var value=myCon.GetNumberLines();
			return value;
		}
	}
}