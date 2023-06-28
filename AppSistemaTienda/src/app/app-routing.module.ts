import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutModule } from '@angular/cdk/layout';

const routes: Routes = [
  {path:'',loadChildren: () => import("./Components/layout/layout.module").then(m => m.LayoutModule)},
  {path:'pages',loadChildren: () => import("./Components/layout/layout.module").then(m => m.LayoutModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
