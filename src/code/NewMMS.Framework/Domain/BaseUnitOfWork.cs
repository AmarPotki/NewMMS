﻿//using Microsoft.EntityFrameworkCore;

//namespace Framework.Domain
//{
//    public abstract class BaseUnitOfWork<TDbContext> :
//		IBaseUnitOfWork where TDbContext : DbContext
//	{
//		public BaseUnitOfWork(TDbContext databaseContext) : base()
//		{
//			DatabaseContext = databaseContext;
//		}

//		// **********
//		protected TDbContext DatabaseContext { get; }
//		// **********

//		// **********
//		/// <summary>
//		/// To detect redundant calls
//		/// </summary>
//		public bool IsDisposed { get; protected set; }
//		// **********

//		/// <summary>
//		/// Public implementation of Dispose pattern callable by consumers.
//		/// </summary>
//		public void Dispose()
//		{
//			Dispose(true);

//			System.GC.SuppressFinalize(this);
//		}

//		/// <summary>
//		/// https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
//		/// </summary>
//		protected virtual void Dispose(bool disposing)
//		{
//			if (IsDisposed)
//			{
//				return;
//			}

//			if (disposing)
//			{
//				// TODO: dispose managed state (managed objects).

//				if (DatabaseContext != null)
//				{
//					DatabaseContext.Dispose();
//				}
//			}

//			// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
//			// TODO: set large fields to null.

//			IsDisposed = true;
//		}

//		public async Task<int> SaveAsync
//		(CancellationToken cancellationToken = default)
//		{
//			var result = 
//				await DatabaseContext.SaveChangesAsync(cancellationToken);

//			return result;
//		}

//		~BaseUnitOfWork()
//		{
//			Dispose(false);
//		}
//	}
//}