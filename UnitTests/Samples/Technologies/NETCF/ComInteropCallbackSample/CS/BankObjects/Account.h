//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

#pragma once
#ifdef STANDARDSHELL_UI_MODEL
#include "resource.h"
#endif
#ifdef POCKETPC2003_UI_MODEL
#include "resourceppc.h"
#endif 
#ifdef SMARTPHONE2003_UI_MODEL
#include "resourcesp.h"
#endif
#ifdef AYGSHELL_UI_MODEL
#include "resourceayg.h"
#endif

#include "BankObjects.h"


#if _CE_DCOM
#pragma message ( "The threading model for this object has been set to 'Free' in the .rgs file. Because you are compiling against an SDK which supports DCOM, you may wish to change this." )
#endif

// Custom HRESULTS for erroroneous transactions
#define ERROR_INSUFFICIENT_FUNDS   MAKE_HRESULT(SEVERITY_ERROR, FACILITY_ITF, 0x1000)
#define ERROR_INVALID_TRANSACTION  MAKE_HRESULT(SEVERITY_ERROR, FACILITY_ITF, 0x1001)

// CAccount

class ATL_NO_VTABLE CAccount : 
	public CComObjectRootEx<CComMultiThreadModel>,
	public CComCoClass<CAccount, &CLSID_Account>,
	public IDispatchImpl<IAccount, &IID_IAccount, &LIBID_BankObjectsLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CAccount();

DECLARE_REGISTRY_RESOURCEID(IDR_ACCOUNT)

DECLARE_NOT_AGGREGATABLE(CAccount)

BEGIN_COM_MAP(CAccount)
	COM_INTERFACE_ENTRY(IAccount)
	COM_INTERFACE_ENTRY(IDispatch)
END_COM_MAP()



	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
		if (accountCallback) 
			accountCallback->Release();
	}

public:
    // IAccount methods
    HRESULT STDMETHODCALLTYPE Initialize(int initialBalance, IAccountCallback *callbackInterface);
    HRESULT STDMETHODCALLTYPE Deposit(int amount);
    HRESULT STDMETHODCALLTYPE Withdraw(int amount);

private:
	int					accountBalance;
	IAccountCallback   *accountCallback;
	void SendUpdateNotification();
};

OBJECT_ENTRY_AUTO(__uuidof(Account), CAccount)
