import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Calculed } from '../models/Calculed';


const baseUrl = 'https://localhost:44332/api';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  getVatAll(): Observable<any> {
    return this.http.get<any>(baseUrl + '/rates/vat')
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  getCountrytAll(): Observable<any> {
    return this.http.get<any>(baseUrl + '/country')
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  getRateByCountryId(value:number): Observable<any> {
    return this.http.get<any>(baseUrl + '/rates?countryId=' + value)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }
  
  getCalculed(value:any): Observable<any> {
    return this.http.post<any>(baseUrl + '/rates/calculed', value)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = error.error.validations;
    }
    return throwError(errorMessage);
  };

}
