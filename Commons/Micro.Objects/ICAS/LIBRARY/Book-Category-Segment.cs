using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Objects.ICAS.LIBRARY
{
	[Serializable]
	public class Book
	{
		public Int64 BookID
		{
			get;
			set;
		}
		public string Title
		{
			get;
			set;
		}
		public string TitleAccessionNo
		{
			get
			{

				int padLength = this.Title.Length;
				return String.Format("{0}{1} {2}", this.Title.ToUpper().PadRight(padLength, '\u00A0'), " - ", this.AccessionNo.ToString());
			}

		}
		public int AuthorID
		{
			get;
			set;
		}
		public string AuthorName
		{
			get;
			set;
		}
		public int PublisherID
		{
			get;
			set;
		}
		public string PublisherName
		{
			get;
			set;
		}
		public int SupplierID
		{
			get;
			set;
		}
		public string SupplierName
		{
			get;
			set;
		}
		public int SubjectID
		{
			get;
			set;
		}

		public int Issued2UserID
		{
			get;
			set;
		}
		public int Issued2UserReferenceID
		{
			get;
			set;
		}
		public string IssuedToUserName
		{
			get;
			set;
		}
		public int AddedByUserID
		{
			get;
			set;
		}

		public int AccessionNo
		{
			get;
			set;
		}
		public DateTime AccessionDate
		{
			get;
			set;
		}
		public string BookType
		{
			get;
			set;
		}
		public int SegmentCode
		{
			get;
			set;
		}
		public int SegmentID
		{
			get;
			set;
		}
		public string SegmentName
		{
			get;
			set;
		}

		public string ClassNo
		{
			get;
			set;
		}
		public string Edition
		{
			get;
			set;
		}
		public int BookYear
		{
			get;
			set;
		}
		public string VolumeNo
		{
			get;
			set;
		}
		public int Pages
		{
			get;
			set;
		}
		public float BookPrice
		{
			get;
			set;
		}
		public string BillNo
		{
			get;
			set;
		}
		public DateTime BillDate
		{
			get;
			set;
		}

		public int CategoryID
		{
			get;
			set;
		}
		public string CategoryCode
		{
			get;
			set;
		}

		public string CategoryName
		{
			get;
			set;

		}
		public string Remarks
		{
			get;
			set;
		}
		public string IsBookIssued
		{
			get;
			set;
		}
		public string IBNNumber
		{
			get;
			set;
		}
		public DateTime AddedDate
		{
			get;
			set;
		}
		public string Book_ImageURL_Small
		{
			get;
			set;
		}
		public string Book_ImageURL_Medium
		{
			get;
			set;
		}
		public string Book_Image_URL_Big
		{
			get;
			set;
		}
		public string Book_PDF_URL
		{
			get;
			set;
		}
		public string IsActive
		{
			get;
			set;
		}
		public string IsDeleted
		{
			get;
			set;
		}

		public string BookStatus
		{
			get;
			set;
		}

		public int OfficeID
		{
			get;
			set;
		}

	}

	[Serializable]
	public class BookCategory
	{
		public int ID
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string Code
		{
			get;
			set;
		}
	}

	[Serializable]
	public class BookSegment
	{
		public int ID
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}
	}

	[Serializable]
	public class BookTransaction
	{
		public long TransactionID
		{
			get;
			set;
		}

		public DateTime TransactionDate
		{
			get;
			set;
		}

		public string TransactionType
		{
			get;
			set;
		}
		public string AccessionNo
		{
			get;
			set;
		}
		public string Title
		{
			get;
			set;
		}
		public string TitleAccessionNo
		{
			get;
			set;
		}
		public long BookID
		{
			get;
			set;
		}

		public int UserID
		{
			get;
			set;
		}
		public string UserName
		{
			get;
			set;
		}

		public int ReceivedFromUserID
		{
			get;
			set;
		}
		public string ReceivedFromUserName
		{
			get;
			set;
		}
		
		public string UserType
		{
			get;
			set;
		}
		public DateTime ExpetedReturnDate
		{
			get
			{
				//return DateTime.Now.AddDays(5); //TODO: use setting to fetch how many days a user can lend a book
				return (this.TransactionDate.AddDays(5));
			}			
		}
		public DateTime ActualReturnDate
		{
			get;
			set;

		}

		public double FineAmount
		{

			get;
			set;
		}
	}
}
