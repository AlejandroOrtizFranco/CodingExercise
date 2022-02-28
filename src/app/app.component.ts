import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Product } from './models/product';
import { ProductHttpServiceService } from './services/product-http-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ToysAndGames';
  productsList: Product[];
  showForm = false;
  showUpdate = false;
  showCreate = false;

  constructor(private service: ProductHttpServiceService) {  }
  ngOnInit(): void {
    this.service.getProducts().subscribe(r => this.productsList = r);
  }

  productForm = new FormGroup({
    id: new FormControl(''),
    name: new FormControl('',Validators.maxLength(50)),
    price: new FormControl('',[Validators.min(0),Validators.max(1000)]),
    company: new FormControl('',Validators.maxLength(50)),
    maxAge: new FormControl('',[Validators.min(0),Validators.max(1000)]),
    description: new FormControl('',Validators.maxLength(100)),
  });

  showProducts(){
    this.service.getProducts().subscribe(r => this.productsList = r);
  }

  create(){
    let product = this.getFormValues();
    this.service.createProduct(product).subscribe();
    this.showForm = false;
    this.showCreate = false;
  }

  update(){
    let product = this.getFormValues();
    this.service.updateProduct(product).subscribe();
    this.showForm = false;
    this.showUpdate = false;
    this.productForm.reset();
  }

  delete(id: number){
    this.service.deleteProduct(id).subscribe();
  }

  updateForm(product: Product){
    this.productForm.get('id').setValue(product.id)
    this.productForm.get('name').setValue(product.name)
    this.productForm.get('price').setValue(product.price)
    this.productForm.get('company').setValue(product.company)
    this.productForm.get('maxAge').setValue(product.ageRestriction)
    this.productForm.get('description').setValue(product.description)
    this.showCreate = false;
    this.showForm = true;
    this.showUpdate = true;
  }

  getFormValues() : Product{
    let product: Product = {
      name: this.productForm.get('name').value,
      price: this.productForm.get('price').value,
      company: this.productForm.get('company').value,
      ageRestriction: this.productForm.get('maxAge').value,
      description: this.productForm.get('description').value
    };
    if(this.showUpdate){
      product.id = this.productForm.get('id').value;
    }
    console.log(product);
    return product;
  }

  addNew(){
    this.productForm.reset();
    this.showForm = true;
    this.showCreate = true;
    this.showUpdate = false;
  }

  cancel(){
    this.productForm.reset();
    this.showForm = false;
    this.showCreate = false;
    this.showUpdate = false;
  }

}
