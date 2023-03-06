import { Component, OnInit } from '@angular/core';
import { DataService } from './services/data.service';
import { Country } from './models/Country';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'TesteAnkix';
  countries: Country[] | undefined;
  
  constructor(private dataService: DataService) {}
  
  ngOnInit(): void {
    this.getCountries();
    this.getVatInit();
  }

  onOptionsSelected(value:any){
    console.log("the selected value is " + value);
}

  getCountries(): void {
    this.dataService.getRateByCountryId(1)
      .subscribe({
        next: (data) => {
          this.countries = data.result;
        },
        error: (e) => console.error(e)
      });
  }

  getVatInit(): void {
    this.dataService.getAll()
      .subscribe({
        next: (data) => {
          this.countries = data.result;
        },
        error: (e) => console.error(e)
      });
  }
}
