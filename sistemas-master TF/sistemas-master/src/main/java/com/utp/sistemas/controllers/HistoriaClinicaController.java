package com.utp.sistemas.controllers;

import com.utp.sistemas.entities.HistoriaClinica;
import com.utp.sistemas.services.HistoriaClinicaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/historias-clinicas")
public class HistoriaClinicaController {

    @Autowired
    private HistoriaClinicaService historiaClinicaService;

    @PostMapping
    public HistoriaClinica createHistoriaClinica(@RequestBody HistoriaClinica historiaClinica) {
        return historiaClinicaService.createHistoriaClinica(historiaClinica);
    }

    @GetMapping
    public List<HistoriaClinica> getAllHistoriaClinicas() {
        return historiaClinicaService.getAllHistoriaClinicas();
    }

    @GetMapping("/{id}")
    public ResponseEntity<HistoriaClinica> getHistoriaClinicaById(@PathVariable Integer id) {
        return historiaClinicaService.getHistoriaClinicaById(id)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PutMapping("/{id}")
    public ResponseEntity<HistoriaClinica> updateHistoriaClinica(@PathVariable Integer id, @RequestBody HistoriaClinica historiaClinicaDetails) {
        HistoriaClinica updatedHistoriaClinica = historiaClinicaService.updateHistoriaClinica(id, historiaClinicaDetails);
        return updatedHistoriaClinica != null ? ResponseEntity.ok(updatedHistoriaClinica) : ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteHistoriaClinica(@PathVariable Integer id) {
        historiaClinicaService.deleteHistoriaClinica(id);
        return ResponseEntity.noContent().build();
    }
}