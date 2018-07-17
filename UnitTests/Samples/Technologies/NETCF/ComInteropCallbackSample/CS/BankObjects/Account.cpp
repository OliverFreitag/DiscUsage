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

#include "stdafx.h"
#include "Account.h"

CAccount::CAccount()
	: accountBalance(0), accountCallback(NULL)
{
}

// Store the initial balance and the pointer to the callback interface.
HRESULT CAccount::Initialize(int initialBalance, IAccountCallback *callbackInterface)
{
	accountBalance = initialBalance;

	accountCallback = callbackInterface;

	if (accountCallback) 
	{
		// Don't forget to AddRef.
		accountCallback->AddRef();

		// send notification that the balance has been updated
		accountCallback->BalanceChanged(initialBalance);
	}

    return S_OK;
}

// When a deposit occurs, update the balance and send
// the balance changed notification.
HRESULT CAccount::Deposit(int amount)
{
	// make sure a positive number is passed
	if (amount < 0)
		return ERROR_INVALID_TRANSACTION;

	accountBalance += amount;
	SendUpdateNotification();

    return S_OK;
}

// When a deposit occurs, update the balance and send
// the balance changed notification.
HRESULT CAccount::Withdraw(int amount)
{
	// make sure a positive number is passed
	if (amount < 0)
		return ERROR_INVALID_TRANSACTION;

	// return an error if there's not enough
	// money in the account
	if ((accountBalance - amount) < 0)
		return ERROR_INSUFFICIENT_FUNDS;

	accountBalance -= amount;
	SendUpdateNotification();

    return S_OK;
}

// Private function to send the balance changed
// notification.  SendUpdateNotification is called
// when either a deposit or withdrawl is made.
void CAccount::SendUpdateNotification()
{	
	// Notify the caller that the balance has changed.  All
	// HRESULTS returned from the caller are ignored as there's
	// no action we'd take as a result.
	if (accountCallback)
		accountCallback->BalanceChanged(accountBalance);
}
